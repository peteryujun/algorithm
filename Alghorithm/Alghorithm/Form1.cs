using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alghorithm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string arrayToString(int[] array)
        {
            string s = "";
            for (int i = 0; i < array.Length; i++)
            {
                s += array[i].ToString() + ",";
            }

            return s;
        }

        private TreeNode getSortedTree()
        {
            TreeNode root = new TreeNode()
            {
                Value = 30,
                LeftChild = new TreeNode()
                {
                    Value = 15,
                    LeftChild = new TreeNode()
                    {
                        Value = 7
                    },
                    RightChild = new TreeNode()
                    {
                        Value = 22,
                        LeftChild = new TreeNode()
                        {
                            Value = 18,
                            LeftChild = new TreeNode()
                            {
                                Value = 16
                            },
                        },
                    }
                },
                RightChild = new TreeNode()
                {
                    Value = 37
                }
            };

            return root;
        }

        #region 根据上排给出十个数，在其下排填出对应的十个数, 要求下排每个数都是先前上排那十个数在下排出现的次数。
        private void button1_Click(object sender, EventArgs e)
        {
            int[] firstArray = new int[] { 0, 1, 2, 3 };
            int[] secondArrary = new int[firstArray.Length];

            for (int i = 0; i < firstArray.Length; i++)
            {
                secondArrary[i] = firstArray[i];
            }

            bool match = false;
            int round = 0;
            while (!match)
            {
                round++;
                match = true;
                for (int i = 0; i < firstArray.Length; i++)
                {
                    int count = getAppearCount(secondArrary, firstArray[i]);
                    if (secondArrary[i] != count)
                    {
                        secondArrary[i] = count;
                        match = false;
                    }
                }

                if (round > firstArray.Length * firstArray.Length)
                {
                    throw new Exception("no match array");
                }
            }

            this.txtResult.Clear();
            this.txtResult.AppendText(arrayToString(firstArray));
            this.txtResult.AppendText(Environment.NewLine);
            this.txtResult.AppendText(arrayToString(secondArrary));
        }

        private int getAppearCount(int[] array, int value)
        {
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                {
                    count++;
                }
            }

            return count;
        }
        #endregion

        #region 全排列
        private void button2_Click(object sender, EventArgs e)
        {
            int[] array = new int[] { 0, 3, 1 };
            this.txtResult.Clear();

            allRange(array, 0);
        }

        private void allRange(int[] array, int index)
        {
            if (index == array.Length - 1)
            {
                this.txtResult.AppendText(arrayToString(array));
                this.txtResult.AppendText(Environment.NewLine);
            }
            else
            {
                for (int i = index; i <= array.Length - 1; i++)
                {
                    int temp = array[i];
                    array[i] = array[index];
                    array[index] = temp;

                    allRange(array, index + 1);

                    temp = array[i];
                    array[i] = array[index];
                    array[index] = temp;
                }
            }
        }
        #endregion

        #region 把二元查找树转变成排序的双向链表
        private void button3_Click(object sender, EventArgs e)
        {
            TreeNode root = getSortedTree();
            this.txtResult.Clear();
            LinkNode head = transferToLinkNode(root);
            this.txtResult.Text = head.ToString();
        }

        private LinkNode transferToLinkNode(TreeNode treeRoot)
        {
            if (treeRoot == null)
            {
                return null;
            }
            else
            {
                LinkNode linkNode = new LinkNode();
                linkNode.Value = treeRoot.Value;

                if (treeRoot.LeftChild != null)
                {
                    LinkNode leftNode = transferToLinkNode(treeRoot.LeftChild);

                    LinkNode leftTail = leftNode;
                    while (leftTail.Next != null)
                    {
                        leftTail = leftTail.Next;
                    }

                    linkNode.Previous = leftTail;
                    linkNode.Previous.Next = linkNode;
                }

                if (treeRoot.RightChild != null)
                {
                    LinkNode rightNode = transferToLinkNode(treeRoot.RightChild);

                    LinkNode rightHead = rightNode;
                    while (rightHead.Previous != null)
                    {
                        rightHead = rightHead.Previous;
                    }

                    linkNode.Next = rightHead;
                    linkNode.Next.Previous = linkNode;
                }

                LinkNode head = linkNode;
                while (head.Previous != null)
                {
                    head = head.Previous;
                }

                return head;
            }
        }
        #endregion

        #region 求子数组的最大和
        private void button4_Click(object sender, EventArgs e)
        {
            int[] a = new int[] { 4, 5, -100, 20 };
            int max = a[0];       //全负情况，返回最大数  
            int sum = 0;
            for (int j = 0; j < a.Length; j++)
            {
                if (sum >= 0)     //如果加上某个元素，sum>=0的话，就加  
                    sum += a[j];
                else
                    sum = a[j];  //如果加上某个元素，sum<0了，就不加  
                if (sum > max)
                    max = sum;
            }

            this.txtResult.Text = max.ToString();
        }

        #endregion

        #region 在二元树中找出和为某一值的所有路径
        private void button5_Click(object sender, EventArgs e)
        {
            TreeNode root = getSortedTree();
            this.txtResult.Clear();
            findPathesThatMatchSum(root, 67, new List<TreeNode>());
        }

        private void findPathesThatMatchSum(TreeNode node, int expectSum, List<TreeNode> path)
        {
            if (node == null)
            {
                return;
            }

            path.Add(node);

            int sumOnThisNode = 0;
            path.ForEach(n => sumOnThisNode += n.Value);

            if (node.LeftChild == null && node.RightChild == null)
            {
                if (sumOnThisNode == expectSum)
                {
                    path.ForEach(n => this.txtResult.AppendText(n.Value.ToString() + "->"));
                    this.txtResult.AppendText(Environment.NewLine);
                }
            }
            else
            {
                if (node.LeftChild != null)
                {
                    findPathesThatMatchSum(node.LeftChild, expectSum, path);
                }

                if (node.RightChild != null)
                {
                    findPathesThatMatchSum(node.RightChild, expectSum, path);
                }
            }

            path.Remove(node);
        }
        #endregion
    }
}
