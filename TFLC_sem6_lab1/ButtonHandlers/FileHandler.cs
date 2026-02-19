using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFLC_sem6_lab1.ButtonHandlers
{
    public class ProcessFile
    {
        public string OpenTxtFile(RichTextBox InputTextBox, string currentFilePath)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = "Выберите текстовый файл";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string fileContent = File.ReadAllText(openFileDialog.FileName);
                        InputTextBox.Text = fileContent;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при чтении файла: " + ex.Message,
                                      "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally { currentFilePath = openFileDialog.FileName; }
                }
            }
            return currentFilePath;
        }

        public void SaveTxtFile(RichTextBox InputTextBox, string currentFilePath, bool isOpened)
        {
            if (isOpened && !string.IsNullOrEmpty(currentFilePath))
            {
                try
                {
                    File.WriteAllText(currentFilePath, InputTextBox.Text);
                    MessageBox.Show("Файл сохранен!", "Успех",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при сохранении: " + ex.Message);
                }
            }
            else
            {
                SaveTxtFileAs(InputTextBox, currentFilePath, isOpened);
            }
        }

        public void SaveTxtFileAs(RichTextBox InputTextBox, string currentFilePath, bool isOpened)
        {
            if (!isOpened) { MessageBox.Show("Файл не открыт!"); return; }
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.Title = "Сохранить текстовый файл";
                saveFileDialog.DefaultExt = "txt";
                saveFileDialog.AddExtension = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string textToSave = InputTextBox.Text;

                        File.WriteAllText(saveFileDialog.FileName, textToSave);
                        MessageBox.Show("Файл успешно сохранен!", "Успех",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при сохранении файла: " + ex.Message,
                                      "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void ExitFile(RichTextBox InputTextBox)
        {
            InputTextBox.Text = "";
            InputTextBox.Enabled = false;
        }
    }
}
