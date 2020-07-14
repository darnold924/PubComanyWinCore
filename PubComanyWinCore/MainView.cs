using System;
using System.Windows.Forms;

namespace PubCompanyWinCore
{
    public partial class MainView : Form
    {
        private readonly PayRollView _payRollView;
        private readonly AuthorView _authorView;
        public MainView(PayRollView payRollView, AuthorView authorView)
        {
            _payRollView = payRollView;
            _authorView = authorView;
  
            InitializeComponent();
        }

       
        private void btnAuthor_Click(object sender, EventArgs e)
        {
            _authorView.ShowDialog();
        }

        private void btnArticle_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnPayroll_Click(object sender, EventArgs e)
        {
            _payRollView.ShowDialog();
        }

        
    }
}
