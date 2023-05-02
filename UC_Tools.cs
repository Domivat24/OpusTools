using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yarhl.FileSystem;
using Yarhl.Media.Text;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System.Reflection.Metadata;
using TypeReference = Mono.Cecil.TypeReference;
using System.Reflection;
using Mono.CompilerServices.SymbolWriter;
using System.Collections;

namespace OpusTool
{
    public partial class UC_Tools : UserControl
    {
        public UC_Tools()
        {
            InitializeComponent();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Selecciona el archivo json";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                exportPo(openFileDialog1.FileName);
                MessageBox.Show("Po exportado correctamente en " + Directory.GetCurrentDirectory());
            }

        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            openFileDialog2.Title = "Selecciona el archivo po con las traducciones";
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                importPo(openFileDialog2.FileName);
            }
        }
        public static void importPo(string filepath)
        {
            MessageBox.Show(String.Format("{0}\\StringDataBase.po", Directory.GetCurrentDirectory()));
            var po = NodeFactory.FromFile(filepath).TransformWith(new Binary2Po()).GetFormatAs<Po>();
            Console.WriteLine(po);

            JObject translation = new JObject();
            foreach (var entry in po.Entries)
            {
                //If the text is untranslated, leaves the original text
                String poText =
                    String.IsNullOrEmpty(entry.Translated) ? entry.Original : entry.Translated;
                if (poText == "<!empty>")
                {
                    poText = String.Empty;
                }
                translation.Add(entry.Context, poText);
            }

            string filePathJson = @"C:\Users\ivanj\Downloads\OPUSROCKET\TextAsset\StringDataBase.json";
            JArray existingArray;

            using (StreamReader reader = new StreamReader(filePathJson))
            {
                // Read the existing array from the file
                existingArray = JArray.Parse(reader.ReadToEnd());

                // Add the new object to the array
                existingArray.Add(translation);


            }
            // Write the updated array back to the file
            using (StreamWriter writer = new StreamWriter("StringDataBase.json"))
            {
                writer.Write(existingArray.ToString());
            }
        }
        public static void exportPo(string filePath)
        {
            // Read the JSON file into a string
            string json;
            using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
            {
                json = reader.ReadToEnd();
            }
            //convert the json in a list of dictionary to manage the data
            var data = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(json);

            //Generate the header for the po
            Po poexport = new Po()
            {
                Header = new PoHeader("Opus: Rocket of Whispers", "ivanjimenez0408@gmail.com", "es")
            };

            //The array contains two 
            for (int i = 0; i < data[1].Count; i++)
            {
                KeyValuePair<string, string> value_Ch = data[0].ElementAt(i);
                KeyValuePair<string, string> value_En = data[1].ElementAt(i);
                var valueString = value_En.Value;
                if (string.IsNullOrEmpty(valueString))
                    valueString = "<!empty>";
                poexport.Add(new PoEntry
                {
                    Original = valueString.Replace("\n\n", "\n"),
                    Context = value_En.Key,
                    ExtractedComments = value_Ch.Value.Replace("\n", " ").Replace("\b", " "),
                });

            }
            for (int i = 0; i < data[6].Count; i++)
            {

                KeyValuePair<string, string> value_Ch = data[7].ElementAt(i);
                KeyValuePair<string, string> value_En = data[6].ElementAt(i);
                var valueString = value_En.Value;
                if (string.IsNullOrEmpty(valueString))
                    valueString = "<!empty>";
                poexport.Add(new PoEntry
                {
                    Original = valueString.Replace("\n\n", "\n"),
                    Context = value_En.Key,
                    ExtractedComments = value_Ch.Value.Replace("\n", " ").Replace("\b", " "),
                });
            }
            new Po2Binary().Convert(poexport).Stream.WriteTo("database.po");
            Console.WriteLine("The file has been exported");
        }
        public void testAssembly(List<Object> databases)
        {
            List<Dictionary<string, string>> list2 = new List<Dictionary<string, string>>();
            foreach (var database in databases)
            {
            }
        }
        private void modify_Dll_Export(string pathDll)
        {
            //string pathDll = Directory.GetCurrentDirectory() + "/Assembly-CSharp.dll";
            //string pathDll = @"E:\Program Files x86\steamapps\common\OPUS Rocket of Whispers\OPUS Rocket of Whispers_Data\Managed\Assembly-CSharp.dll";
            var resolver = new DefaultAssemblyResolver();
            resolver.AddSearchDirectory(pathDll);
            using (var assembly = Mono.Cecil.AssemblyDefinition.ReadAssembly(pathDll+"/Assembly-Csharp.dll", new ReaderParameters { ReadWrite = true, AssemblyResolver = resolver }))
            {
                Mono.Cecil.TypeDefinition manager_Class = assembly.MainModule.Types.FirstOrDefault(type => type.Name == "LocalizationManager");
                Mono.Cecil.MethodDefinition cacheDatabase = manager_Class.Methods.FirstOrDefault(method => method.Name == "ResetCacheStringDataBase");

                MethodInfo writeLineMethod = typeof(UC_Tools).GetMethod("testAssembly");
                Console.WriteLine(writeLineMethod);

                MethodReference methodReference = assembly.MainModule.ImportReference(writeLineMethod);

                ILProcessor ilprocessor = cacheDatabase.Body.GetILProcessor();

                //References and constructors
                var listRef = assembly.MainModule.ImportReference(typeof(List<Dictionary<string, string>>));
                var listCtor = assembly.MainModule.ImportReference(typeof(List<Dictionary<string, string>>).GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, new Type[0], null));
                var listAddMethod = assembly.MainModule.ImportReference(typeof(List<Dictionary<string, string>>).GetMethod("Add", new[] { typeof(Dictionary<string, string>) }));

                // variables
                var varList = new VariableDefinition(listRef);
                cacheDatabase.Body.Variables.Add(varList);
                //need to initialize the variable, even though it will always find the variable
                VariableDefinition varGoogleDataBaseDicString = default;
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

                var ldLocList = ilprocessor.Create(OpCodes.Ldloc, varList);
                //var callAddList = ilprocessor.Create  (OpCodes.Call, listAddMethod);
                var ldLocDatabase = ilprocessor.Create(OpCodes.Ldloc, varGoogleDataBaseDicString);
                var callgoogleDataBaseDatasRef = ilprocessor.Create(OpCodes.Call, googleDataBaseDatasRef);
                var ldLocJValue = ilprocessor.Create(OpCodes.Ldloc, cacheDatabase.Body.Variables[3]);
                var ldElemRefJ = ilprocessor.Create(OpCodes.Ldelem_Ref);
                var CallVirtAddMethod = ilprocessor.Create(OpCodes.Callvirt, listAddMethod);


                //List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();

                ilprocessor.InsertBefore(cacheDatabase.Body.Instructions[0], newObjList);
                ilprocessor.InsertBefore(cacheDatabase.Body.Instructions[0], stLocList);


                // list.Add(googleDataBaseDicString.datas[j]);
                Instruction targetInstruction = cacheDatabase.Body.Instructions[10];
                ilprocessor.InsertBefore(targetInstruction, ldLocList);
                ilprocessor.InsertBefore(targetInstruction, ldLocDatabase);
                ilprocessor.InsertBefore(targetInstruction, callgoogleDataBaseDatasRef);
                ilprocessor.InsertBefore(targetInstruction, ldLocJValue);
                ilprocessor.InsertBefore(targetInstruction, ldElemRefJ);

                try
                {
                    assembly.Write();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
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
    }
}
