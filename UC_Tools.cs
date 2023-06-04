using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using Yarhl.FileSystem;
using Yarhl.Media.Text;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System.Reflection;
using System.Resources;
using System.Diagnostics;
using Mono.Cecil.Rocks;

namespace OpusTool
{
    public partial class UC_Tools : UserControl
    {
        private CultureManager<UC_Tools> _cultureManager;
        public ResourceManager rm;
        private int[] languagesIndex = {7, 6, 8, 9, 10, 11, 12 };

        public UC_Tools()
        {
            InitializeComponent();
            _cultureManager = new CultureManager<UC_Tools>(this);
            _cultureManager.updateCurrentControlCulture();
            rm = _cultureManager.rm;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            
            try
            {
                openFileDialog1.Title = rm.GetString("messageSelectJSON");
                openFileDialog1.Multiselect = false;
                openFileDialog1.FileName = String.Empty;
                openFileDialog1.Filter = "JSON|*.json|All Files|*.*";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    exportPo(openFileDialog1.FileName);
                }
            } catch(Exception ex)
            {
                MessageBox.Show(String.Format(format: "{0} {1}",rm.GetString("generalError"), ex.ToString()), rm.GetString("generalErrorCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public static void importPo(string filepath)
        {
            var po = NodeFactory.FromFile(filepath).TransformWith(new Binary2Po()).GetFormatAs<Po>();
            Console.WriteLine(po);

            JObject translation = new JObject();
            foreach (var entry in po.Entries)
            {
                //If the text is untranslated, leaves the original text
                String poText =
                    String.IsNullOrEmpty(entry.Translated) ? entry.Original : entry.Translated;
                poText = poText == "<!empty>" ? String.Empty : poText;
                poText = entry.Context == "LocKey" ? "EN" : poText;
                

                translation.Add(entry.Context, poText);
            }

            string filePathJson = Path.Combine(Properties.Settings.Default.GamePath,"translation.json");
           
            using (StreamWriter writer = new StreamWriter(filePathJson))
            {
                writer.Write(translation.ToString());
            }
        }
        public void exportPo(string filePath)
        {
            List<Dictionary<string, string>> data;
            try
            {
                // Read the JSON file into a string
                string json;
                using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
                {
                    json = reader.ReadToEnd();
                }
                //convert the json in a list of dictionary to manage the data
                data = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(json);

                //we assure that the json is valid
                var kvpLockKey = data[0].ElementAt(0);
                if (kvpLockKey.Key != "LocKey")
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(format: "{0} {1}", rm.GetString("messageErrorSelect"), ex.ToString()), rm.GetString("generalErrorCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            using var customForm = new CustomInputBox();
            if (customForm.ShowDialog() == DialogResult.OK)
            {
                //Generate the header for the po
                Po poexport = new Po()
                {
                    Header = new PoHeader(customForm.projectId, customForm.projectEmail, customForm.languageCode),
                };
                //if the user does not want comments, then the code needs to change and now I can do it with foreaches
                if (customForm.languageCommentIndex == 7)
                {
                    //Every language is split between two objects inside the array, that's why two loops are needed
                    foreach (var kvp in data[customForm.languageOriginalIndex])
                    {
                        var valueString = kvp.Value;
                        if (string.IsNullOrEmpty(valueString))
                            valueString = "<!empty>";
                        poexport.Add(new PoEntry
                        {
                            Original = valueString.Replace("\n\n", "\n"),
                            Context = kvp.Key,
                        });
                    }
                    foreach (var kvp in data[languagesIndex[customForm.languageOriginalIndex]])
                    {
                        var valueString = kvp.Value;
                        if (string.IsNullOrEmpty(valueString))
                            valueString = "<!empty>";
                        poexport.Add(new PoEntry
                        {
                            Original = valueString.Replace("\n\n", "\n"),
                            Context = kvp.Key,
                        });
                    }
                }
                else
                {
                    //Every language is split between two objects inside the array, that's why two loops are needed
                    for (int i = 0; i < data[customForm.languageOriginalIndex].Count; i++)
                    {
                        KeyValuePair<string, string> value_Comment = data[customForm.languageCommentIndex].ElementAt(i);
                        KeyValuePair<string, string> value_Original = data[customForm.languageOriginalIndex].ElementAt(i);
                        var valueString = value_Original.Value;
                        if (string.IsNullOrEmpty(valueString))
                            valueString = "<!empty>";
                        poexport.Add(new PoEntry
                        {
                            Original = valueString.Replace("\n\n", "\n"),
                            Context = value_Original.Key,
                            ExtractedComments = value_Comment.Value.Replace("\n", " ").Replace("\b", " "),
                        });

                    }
                    for (int i = 0; i < data[languagesIndex[customForm.languageOriginalIndex]].Count; i++)
                    {
                        KeyValuePair<string, string> value_Comment = data[languagesIndex[customForm.languageCommentIndex]].ElementAt(i);
                        KeyValuePair<string, string> value_Original = data[languagesIndex[customForm.languageOriginalIndex]].ElementAt(i);
                        var valueString = value_Original.Value;
                        if (string.IsNullOrEmpty(valueString))
                            valueString = "<!empty>";
                        poexport.Add(new PoEntry
                        {
                            Original = valueString.Replace("\n\n", "\n"),
                            Context = value_Original.Key,
                            ExtractedComments = value_Comment.Value.Replace("\n", " ").Replace("\b", " "),
                        });
                    }
                }
                //save the file exported file to user's choice
                var sfd = new SaveFileDialog();
                sfd.Filter = "PO (*.po)|*.po";
                sfd.Title = rm.GetString("savePoDialog");
                sfd.FileName = String.Format(@"Opus Rocket of Whispers_{0}_translation.po",customForm.languageCode);
                if (sfd.ShowDialog()==DialogResult.OK)
                {
                    new Po2Binary().Convert(poexport).Stream.WriteTo(sfd.FileName);
                    Console.WriteLine("The file has been exported");
                    MessageBox.Show("Po exportado correctamente en " + Directory.GetCurrentDirectory());
                } else
                {
                    MessageBox.Show(rm.GetString("messageAborted"));
                }

            }
        }
        private void modify_Dll_Export(string pathDll)
        {
            var resolver = new DefaultAssemblyResolver();
            resolver.AddSearchDirectory(Path.Combine(Properties.Settings.Default.GamePath,"OPUS Rocket of Whispers_Data","Managed"));
            using (var assembly = Mono.Cecil.AssemblyDefinition.ReadAssembly(pathDll+"/Original/Assembly-Csharp.dll", new ReaderParameters { ReadWrite = true, AssemblyResolver = resolver }))
            {
                Mono.Cecil.TypeDefinition manager_Class = assembly.MainModule.Types.FirstOrDefault(type => type.Name == "LocalizationManager");
                Mono.Cecil.MethodDefinition cacheDatabase = manager_Class.Methods.FirstOrDefault(method => method.Name == "ResetCacheStringDataBase");

                ILProcessor ilprocessor = cacheDatabase.Body.GetILProcessor();

                //References and constructors
                var listRef = assembly.MainModule.ImportReference(typeof(List<Dictionary<string, string>>));
                var listCtor = assembly.MainModule.ImportReference(typeof(List<Dictionary<string, string>>).GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, new Type[0], null));
                var listAddMethod = assembly.MainModule.ImportReference(typeof(List<Dictionary<string, string>>).GetMethod("Add", new[] { typeof(Dictionary<string, string>) }));
                var fileReadMethod = assembly.MainModule.ImportReference(typeof(File).GetMethod("ReadAllText", new[] { typeof(string) } ));
                MethodReference jsonDeserializeMethod = assembly.MainModule.ImportReference(typeof(JsonConvert).GetMethods().Where(x => x.Name == "DeserializeObject").FirstOrDefault(x => x.IsGenericMethod));

                var dictionaryType = assembly.MainModule.ImportReference(typeof(Dictionary<string, string>));

                var fld_dictionary_1 = new FieldDefinition("dictionary", Mono.Cecil.FieldAttributes.Private, assembly.MainModule.ImportReference(typeof(Dictionary<,>)).MakeGenericInstanceType(assembly.MainModule.TypeSystem.String, assembly.MainModule.TypeSystem.String));

                // variables
                var varList = new VariableDefinition(listRef);
                cacheDatabase.Body.Variables.Add(varList);
                //need to initialize the variable, even though it will always find the variable
                VariableDefinition varGoogleDataBaseDicString = default;
                foreach(var instruction in cacheDatabase.Body.Instructions)
                {
                    Debug.WriteLine(instruction.ToString());
                }
                // Get the instance of the variable that stores the database data
                foreach (VariableDefinition variable in cacheDatabase.Body.Variables)
                {
                    if (variable.VariableType.FullName == "TeamSignal.Utilities.GoogleData.GoogleDataBaseDicString")
                    {
                        varGoogleDataBaseDicString = variable;
                        Console.WriteLine(variable.VariableType.GetType());

                    }
                    Console.WriteLine(variable.VariableType.FullName);
                }
                //Reference to the property .datas of the googleDataBaseDicString
                var googleDataBaseDatasRef = assembly.MainModule.ImportReference(varGoogleDataBaseDicString.VariableType.Resolve().Properties.Single(p => p.Name == "datas").GetMethod);


                //Instructions
                var newObjList = ilprocessor.Create(OpCodes.Newobj, listCtor);
                var stLocList = ilprocessor.Create(OpCodes.Stloc, varList);

                var ldStrTranslationFile = ilprocessor.Create(OpCodes.Ldstr, "translation.json");
                var callFileRead = ilprocessor.Create(OpCodes.Call, fileReadMethod);
                var callJsonDeserialize = ilprocessor.Create(OpCodes.Call, jsonDeserializeMethod);

                var ldLocList = ilprocessor.Create(OpCodes.Ldloc, varList);
                //var callAddList = ilprocessor.Create  (OpCodes.Call, listAddMethod);
                var ldLocDatabase = ilprocessor.Create(OpCodes.Ldloc, varGoogleDataBaseDicString);
                var callgoogleDataBaseDatasRef = ilprocessor.Create(OpCodes.Call, googleDataBaseDatasRef);
                var ldLocJValue = ilprocessor.Create(OpCodes.Ldloc, cacheDatabase.Body.Variables[3]);
                var ldElemRefJ = ilprocessor.Create(OpCodes.Ldelem_Ref);
                var CallVirtAddMethod = ilprocessor.Create(OpCodes.Callvirt, listAddMethod);

                //Dictionary<string, string> dictionary = new<Dictionary<string, string>>(File.ReadAllText("translation.json"));

                //ilprocessor.InsertBefore(cacheDatabase.Body.Instructions[0], ilprocessor.Create(OpCodes.Ldarg_0));
                ilprocessor.InsertBefore(cacheDatabase.Body.Instructions[0], ldStrTranslationFile);
                ilprocessor.InsertBefore(cacheDatabase.Body.Instructions[0], callFileRead);
                ilprocessor.InsertBefore(cacheDatabase.Body.Instructions[0], callJsonDeserialize);
                ilprocessor.InsertBefore(cacheDatabase.Body.Instructions[0], ilprocessor.Create(OpCodes.Stloc_0));
                //ilprocessor.InsertBefore(cacheDatabase.Body.Instructions[0], ilprocessor.Create(OpCodes.Stfld, fld_dictionary_1));


                //List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();

                //ilprocessor.InsertBefore(cacheDatabase.Body.Instructions[0], newObjList);
                //ilprocessor.InsertBefore(cacheDatabase.Body.Instructions[0], stLocList);


                // list.Add(googleDataBaseDicString.datas[j]);

                /*
                 
                                InstructionPattern pattern = new InstructionPattern(
                                    OpCodes.Ldloc_0,
                                    OpCodes.Br_S,
                                    OpCodes.Ldc_I4_S,
                                    OpCodes.Blt_S,
                                    OpCodes.Ldarg_0,
                                    OpCodes.Ldloc_0,
                                    OpCodes.Ldelem_Ref,
                                    OpCodes.Callvirt,
                                    OpCodes.Stloc_1,
                                    OpCodes.Ldloc_0,
                                    OpCodes.Ldc_I4_1,
                                    OpCodes.Add,
                                    OpCodes.Stloc_0,
                                    OpCodes.Br_S
                    );
                                MethodBodyScanner scanner = new MethodBodyScanner(cacheDatabase.Body);

                                MethodBodyScannerResult scannerResult = scanner.Scan(pattern);



                                // Scan the method body for the pattern
                                MethodBodyScannerResult result = scanner.Scan(pattern);

                                // If a match was found, insert the new instruction after the loop
                                if (result.Success)
                                {
                                    Instruction newInstruction = Instruction.Create(OpCodes.Nop);
                                    ilprocessor.InsertAfter(result.Match, newInstruction);
                                }


                                // list.Add(googleDataBaseDicString.datas[j]);
                                Instruction loopExitInstruction = cacheDatabase.Body.Instructions.Single(i =>
                                    i.OpCode == OpCodes.Brfalse && i.Operand is Instruction &&
                                    ((Instruction)i.Operand).Operand == cacheDatabase.Body.Variables[0]);
                                ilprocessor.InsertAfter(result.Match, ldLocList);
                                ilprocessor.InsertAfter(result.Match, ldLocDatabase);
                                ilprocessor.InsertAfter(result.Match, callgoogleDataBaseDatasRef);
                                ilprocessor.InsertAfter(result.Match, ldLocJValue);
                                ilprocessor.InsertAfter(result.Match, ldElemRefJ);
                 * */

                try
                {
                    assembly.Write();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }



        }

        private void UC_Tools_Load_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog()== DialogResult.OK)
            {
                modify_Dll_Export(folderBrowserDialog1.SelectedPath);
            }
        }

        private void btnImportPo_Click(object sender, EventArgs e)
        {
            openFileDialog2.Title = rm.GetString("messageSelectPO");
            openFileDialog2.Multiselect = false;
            openFileDialog2.FileName = String.Empty;
            openFileDialog2.Filter = "PO|*.po|All Files|*.*";
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {

                try {
                    importPo(openFileDialog2.FileName);
                    MessageBox.Show("Archivo importado correctamente");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(String.Format(format: "{0} {1}", rm.GetString("generalError"), ex.ToString()), rm.GetString("generalErrorCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
