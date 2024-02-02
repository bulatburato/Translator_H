using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Translator_H
{
    public partial class Form1 : Form
    {
        // Definiere die Methode, die ein Dictionary zurückgibt
        public Dictionary<string, string> CreateDictionary()
        {
            // Erstelle ein Dictionary, das die Buchstaben aus der Spalte Deutsch als Schlüssel und die Buchstaben aus der Spalte Hells als Wert verwendet
            Dictionary<string, string> dict = new Dictionary<string, string>();

            // Erstelle einen StreamReader, der die alphabet.csv-Datei öffnet
            StreamReader reader = new StreamReader(Environment.CurrentDirectory + @"\alphabet.csv");

            // Lese die erste Zeile der Datei (die Überschriften) und ignoriere sie
            reader.ReadLine();

            // Lese die restlichen Zeilen der Datei in einer Schleife
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                // Teile die Zeile an dem Komma auf, um die beiden Buchstaben zu erhalten
                string[] parts = line.Split(';');

                // Füge das Schlüssel-Wert-Paar dem Dictionary hinzu
                dict.Add(parts[0], parts[1]);
            }

            // Schließe den StreamReader
            reader.Close();

            // Gib das Dictionary zurück
            return dict;
        }

        // Definiere die Methode, die ein umgekehrtes Dictionary zurückgibt
        public Dictionary<string, string> CreateReverseDictionary()
        {
            // Erstelle ein Dictionary, das die Buchstaben aus der Spalte Hells als Schlüssel und die Buchstaben aus der Spalte Deutsch als Wert verwendet
            Dictionary<string, string> reverseDict = new Dictionary<string, string>();

            // Erstelle einen StreamReader, der die alphabet.csv-Datei öffnet
            StreamReader reader = new StreamReader(Environment.CurrentDirectory + @"\alphabet.csv");

            // Lese die erste Zeile der Datei (die Überschriften) und ignoriere sie
            reader.ReadLine();

            // Lese die restlichen Zeilen der Datei in einer Schleife
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                // Teile die Zeile an dem Komma auf, um die beiden Buchstaben zu erhalten
                string[] parts = line.Split(';');

                // Füge das Schlüssel-Wert-Paar dem Dictionary hinzu
                reverseDict.Add(parts[1], parts[0]);
            }

            // Schließe den StreamReader
            reader.Close();

            // Gib das Dictionary zurück
            return reverseDict;
        }

        // Deklariere eine Variable für den StreamReader
        StreamReader reader;

        // Deklariere eine Variable für das Dictionary
        Dictionary<string, string> dict;

        // Deklariere eine Variable für das umgekehrte Dictionary
        Dictionary<string, string> reverseDict;

        // Deklariere eine Variable für den Dateinamen
        string fileName;

        // Deklariere eine Variable für den Pfad
         string path;

        public Form1()
        {
            InitializeComponent();
        }
        

        private void Form1_Load(object sender, EventArgs e)

        {
            // Initialisiere den StreamReader mit dem Pfad zu deiner Datei
            reader = new StreamReader(Environment.CurrentDirectory + @"\alphabet.csv");

            // Initialisiere das Dictionary mit der Methode, die du geschrieben hast
            dict = CreateDictionary();

            // Initialisiere das umgekehrte Dictionary mit der Methode, die du geschrieben hast
            reverseDict = CreateReverseDictionary();

            // Ändere die Höhe der richTextBox3 auf 50
            richTextBox3.Height = 50;

            // Erstelle einen Dateinamen aus dem aktuellen Datum und der aktuellen Uhrzeit
            fileName = DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            // Erstelle einen Pfad zu dem Ordner, in dem die Datei gespeichert werden soll
            _ = Environment.CurrentDirectory + @"";
            // Erstelle einen Pfad zu dem Programmordner

        }
        private void SaveMyFile()
        {
            // Create a SaveFileDialog to request a path and file name to save to.
            SaveFileDialog saveFile1 = new SaveFileDialog();

            // Initialize the SaveFileDialog to specify the RTF extention for the file.
            saveFile1.DefaultExt = "*.rtf";
            saveFile1.Filter = "RTF Files|*.rtf";

            // Determine whether the user selected a file name from the saveFileDialog.
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               saveFile1.FileName.Length > 0)
            {
                // Save the contents of the RichTextBox into the file.
                richTextBox1.SaveFile(saveFile1.FileName);
            }
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Lese die Eingabe aus der richTextBox1
            string input = richTextBox1.Text;

            // Erstelle eine Variable für die Ausgabe
            string output = "";

            // Übersetze die Eingabe mit dem Dictionary in einer Schleife
            foreach (char c in input)
            {
                // Prüfe, ob der Buchstabe im Dictionary vorhanden ist
                if (dict.ContainsKey(c.ToString()))
                {
                    // Ersetze den Buchstaben mit dem entsprechenden Zeichen aus dem Dictionary
                    output += dict[c.ToString()];
                }
                else
                {
                    // Lasse den Buchstaben unverändert
                    output += c;
                }
            }

            // Zeige die Ausgabe in der richTextBox2 an
            richTextBox2.Text = output;
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveMyFile();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Lese die Eingabe aus der richTextBox2
            string input = richTextBox2.Text;

            // Erstelle eine Variable für die Ausgabe
            string output = "";

            // Übersetze die Eingabe mit dem umgekehrten Dictionary in einer Schleife
            foreach (char c in input)
            {
                // Prüfe, ob der Buchstabe im umgekehrten Dictionary vorhanden ist
                if (reverseDict.ContainsKey(c.ToString()))
                {
                    // Ersetze den Buchstaben mit dem entsprechenden Zeichen aus dem umgekehrten Dictionary
                    output += reverseDict[c.ToString()];
                }
                else
                {
                    // Lasse den Buchstaben unverändert
                    output += c;
                }
            }

            // Zeige die Ausgabe in der richTextBox3 an
            richTextBox3.Text = output;
        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        // Definiere die Methode, die die Ausgabe von button1 in die Datei schreibt

    }
}

