using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW5KDolan
{
    /* Program Name: HW5KDolan or Data Structures
     * Programmers: Kevin Dolan
     * Description: Peg Game solver. Pain. Pain.
     * Instructor: Prof. Bierre
     * Class: IGME 106
     */
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            //board objects 0 through 14 created
            Board board1 = new Board(0);
            Board board2 = new Board(1);
            Board board3 = new Board(2);
            Board board4 = new Board(3);
            Board board5 = new Board(4);
            Board board6 = new Board(5);
            Board board7 = new Board(6);
            Board board8 = new Board(7);
            Board board9 = new Board(8);
            Board board10 = new Board(9);
            Board board11 = new Board(10);
            Board board12 = new Board(11);
            Board board13 = new Board(12);
            Board board14 = new Board(13);
            Board board15 = new Board(14);

            //moveListBox.Items.Add(board1.Rigged()); 
            List<string> solution = board1.Solve();
            foreach (string s in solution)
            {
                moveListBox.Items.Add(s);
            }

            solution = board2.Solve();
            foreach (string s in solution)
            {
                moveListBox.Items.Add(s);
            }

            solution = board3.Solve();
            foreach (string s in solution)
            {
                moveListBox.Items.Add(s);
            }

            solution = board4.Solve();
            foreach (string s in solution)
            {
                moveListBox.Items.Add(s);
            }

            solution = board5.Solve();
            foreach (string s in solution)
            {
                moveListBox.Items.Add(s);
            }

            solution = board6.Solve();
            foreach (string s in solution)
            {
                moveListBox.Items.Add(s);
            }

            solution = board7.Solve();
            foreach (string s in solution)
            {
                moveListBox.Items.Add(s);
            }

            solution = board8.Solve();
            foreach (string s in solution)
            {
                moveListBox.Items.Add(s);
            }

            solution = board9.Solve();
            foreach (string s in solution)
            {
                moveListBox.Items.Add(s);
            }

            solution = board10.Solve();
            foreach (string s in solution)
            {
                moveListBox.Items.Add(s);
            }

            solution = board11.Solve();
            foreach (string s in solution)
            {
                moveListBox.Items.Add(s);
            }

            solution = board12.Solve();
            foreach (string s in solution)
            {
                moveListBox.Items.Add(s);
            }

            solution = board13.Solve();
            foreach (string s in solution)
            {
                moveListBox.Items.Add(s);
            }

            solution = board14.Solve();
            foreach (string s in solution)
            {
                moveListBox.Items.Add(s);
            }

            solution = board15.Solve();
            foreach (string s in solution)
            {
                moveListBox.Items.Add(s);
            }

            //god is dead
        }
    }
}
