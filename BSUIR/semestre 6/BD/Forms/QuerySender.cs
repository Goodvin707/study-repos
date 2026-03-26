using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelAgency_DB_GUI.Utils;

namespace TravelAgency_DB_GUI.Forms
{
    public partial class QuerySender : Form
    {
        private bool isHighlighting = false;

        // Цвета для разных элементов
        private static readonly Color KeywordColor = Color.Blue;
        private static readonly Color StringColor = Color.Brown;
        private static readonly Color CommentColor = Color.Green;
        private static readonly Color CommentColorSecondary = Color.SeaGreen;
        private static readonly Color NumberColor = Color.Magenta;
        public QuerySender() => InitializeComponent();

        private void CloseButton_Click(object sender, EventArgs e) => this.Close();

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            resultRichTextBox.Text = "";
            string s = richTextBox.Text.ToLower();

            if (s.Contains("insert") || s.Contains("update") || s.Contains("delete"))
                resultRichTextBox.Text += "Результат запроса: \r\n Количество затронутых строк: " + DatabaseController.ExecuteNonQuery(richTextBox.Text);
            else
            {
                if (s.Contains("select") || s.Contains("show"))
                {
                    using (MySqlDataReader reader = DatabaseController.ExecuteReader(richTextBox.Text))
                    {
                        if (reader != null)
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            dataGridView1.DataSource = dt;
                        }
                    }
                    resultRichTextBox.Text += "Запрос на выборку выполен успешно. \r\n";

                }
                if (s.Contains("count") || s.Contains("max") || s.Contains("sum"))
                    resultRichTextBox.Text += "Первая ячейка с агрегацией запроса: \r\n" + DatabaseController.ExecuteScalar(richTextBox.Text)?.ToString();
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (!isHighlighting)
            {
                isHighlighting = true;
                HighlightAllText();
                isHighlighting = false;
            }
        }

        private void HighlightAllText()
        {
            int selectionStart = richTextBox.SelectionStart;
            int selectionLength = richTextBox.SelectionLength;
            string text = richTextBox.Text;

            richTextBox.SelectAll();
            richTextBox.SelectionColor = Color.Black;
            richTextBox.SelectionFont = new Font("Consolas", 10, FontStyle.Regular);

            // Подсветка ключевых слов
            HighlightKeywords(text);

            // Подсветка строк
            HighlightStrings(text);

            // Подсветка комментариев
            HighlightComments(text);

            // Подсветка чисел
            HighlightNumbers(text);

            richTextBox.Select(selectionStart, selectionLength);
        }

        private void HighlightKeywords(string text)
        {
            string[] keywords = {
            "SELECT", "UPDATE", "DELETE", "INSERT", "FROM", "WHERE",
            "AND", "OR", "JOIN", "LEFT", "RIGHT", "INNER", "OUTER",
            "ON", "GROUP", "BY", "ORDER", "ASC", "DESC", "HAVING",
            "SET", "VALUES", "INTO", "TOP", "DISTINCT", "AS", "NULL",
            "NOT", "IN", "BETWEEN", "LIKE", "IS", "CREATE", "TABLE",
            "ALTER", "DROP", "PRIMARY", "KEY", "FOREIGN", "REFERENCES",
            "SHOW", "IF", "ELSE", "DETERMINISTIC","BEGIN","DECLARE",
            "DATE", "BOOLEAN", "END", "RETURN"
            };

            foreach (string keyword in keywords)
            {
                int startIndex = 0;
                while (startIndex < text.Length)
                {
                    int index = text.IndexOf(keyword, startIndex, StringComparison.OrdinalIgnoreCase);
                    if (index == -1) break;

                    bool isStartValid = index == 0 || !char.IsLetterOrDigit(text[index - 1]);
                    bool isEndValid = index + keyword.Length == text.Length ||
                                      !char.IsLetterOrDigit(text[index + keyword.Length]);

                    if (isStartValid && isEndValid)
                    {
                        richTextBox.Select(index, keyword.Length);
                        richTextBox.SelectionColor = KeywordColor;
                        richTextBox.SelectionFont = new Font("Consolas", 10, FontStyle.Bold);
                    }

                    startIndex = index + keyword.Length;
                }
            }
        }

        private void HighlightStrings(string text)
        {
            int startIndex = 0;
            while (startIndex < text.Length)
            {
                int quoteStart = text.IndexOf("'", startIndex);
                if (quoteStart == -1) break;

                int quoteEnd = text.IndexOf("'", quoteStart + 1);
                if (quoteEnd == -1) break;

                richTextBox.Select(quoteStart, quoteEnd - quoteStart + 1);
                richTextBox.SelectionColor = StringColor;

                startIndex = quoteEnd + 1;
            }

            startIndex = 0;
            while (startIndex < text.Length)
            {
                int quoteStart = text.IndexOf("\"", startIndex);
                if (quoteStart == -1) break;

                int quoteEnd = text.IndexOf("\"", quoteStart + 1);
                if (quoteEnd == -1) break;

                richTextBox.Select(quoteStart, quoteEnd - quoteStart + 1);
                richTextBox.SelectionColor = StringColor;

                startIndex = quoteEnd + 1;
            }

        }

        private void HighlightComments(string text)
        {
            // Однострочные комментарии --
            int startIndex = 0;
            while (startIndex < text.Length)
            {
                int commentStart = text.IndexOf("--", startIndex);
                if (commentStart == -1) break;

                int lineEnd = text.IndexOf("\n", commentStart);
                if (lineEnd == -1) lineEnd = text.Length;

                richTextBox.Select(commentStart, lineEnd - commentStart);
                richTextBox.SelectionColor = CommentColor;

                startIndex = lineEnd + 1;
            }

            // Многострочные комментарии /* */
            startIndex = 0;
            while (startIndex < text.Length)
            {
                int commentStart = text.IndexOf("/*", startIndex);
                if (commentStart == -1) break;

                int commentEnd = text.IndexOf("*/", commentStart);
                if (commentEnd == -1) break;

                richTextBox.Select(commentStart, commentEnd - commentStart + 2);
                richTextBox.SelectionColor = CommentColorSecondary;

                startIndex = commentEnd + 2;
            }
        }

        private void HighlightNumbers(string text)
        {
            System.Text.RegularExpressions.Regex numberRegex =
                new System.Text.RegularExpressions.Regex(@"\b\d+(\.\d+)?\b");

            foreach (System.Text.RegularExpressions.Match match in numberRegex.Matches(text))
            {
                richTextBox.Select(match.Index, match.Length);
                richTextBox.SelectionColor = NumberColor;
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e) { }
    }
}
