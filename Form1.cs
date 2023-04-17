using System.Media;
using System.Text;
using NAudio.Wave;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Yarhl.FileSystem;
using Yarhl.Media.Text;

namespace OpusTool
{
    public partial class Form1 : Form
    {
        private WaveOutEvent backgroundMusic;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            backgroundMusic = new WaveOutEvent();
            var audioFile = new AudioFileReader("backgroundMusic.mp3");
            backgroundMusic.Init(new LoopStream(audioFile));
            backgroundMusic.Play();

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            backgroundMusic.Volume = (float)trackBar1.Value / 100f;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            backgroundMusic.Dispose();
        }
        public static void exportPo(string filePath)
        {
            // Read the JSON file into a string
            string json;
            using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
            {
                json = reader.ReadToEnd();
            }
            //Alternative method without assuring the encoding
            //string json = File.ReadAllText(@"C:\Users\ivanj\Downloads\OPUSROCKET\TextAsset\StringDataBase.json");

            //convert the json in a list of dictionary to manage the data
            var data = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(json);

            //Generate the header for the po
            Po poexport = new Po()
            {
                Header = new PoHeader("Opus: Rocket of Whispers", "ivanjimenez0408@gmail.com", "es")
            };


            for (int i = 0; i < data[1].Count; i++)
            {
                //as I also want to store as a comment the original string, I get the key values from the chinese json element
                //main reason I did not use a foreach
                KeyValuePair<string, string> value_Ch = data[0].ElementAt(i);
                KeyValuePair<string, string> value_En = data[1].ElementAt(i);
                var valueString = value_En.Value;
                if (string.IsNullOrEmpty(valueString))
                    valueString = "<!empty>";
                poexport.Add(new PoEntry
                {
                    Original = valueString.Replace("\n\n","\n"),
                    Context = value_En.Key,
                    ExtractedComments = value_Ch.Value.Replace("\n"," ").Replace("\b"," "),
                });

            }
            new Po2Binary().Convert(poexport).Stream.WriteTo("StringDataBase.po");
            Console.WriteLine("The file has been exported");

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

        private void button1_Click(object sender, EventArgs e)
        {
            importPo(String.Format("{0}\\StringDataBase.po", Directory.GetCurrentDirectory()));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            exportPo(@"C:\Users\ivanj\Downloads\OPUSROCKET\TextAsset\StringDataBase");

            MessageBox.Show("Po exportado correctamente en " + Directory.GetCurrentDirectory());


        }
    }
}