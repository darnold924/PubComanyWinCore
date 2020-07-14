using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BLL;
using Entities;
using PubCompanyWinCore.IView;
using PubCompanyWinCore.Presenters;

namespace PubCompanyWinCore
{
    public partial class AuthorView : Form, IAuthorView
    {
        private IAuthorDM _authorDm;
        private AuthorViewPresenter mPresenter;
        private List<DtoAuthor> dtoauthors = new List<DtoAuthor>();
        private int currentauthoridx;

        public AuthorView(IAuthorDM authorDm)
        {
            _authorDm = authorDm;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            mPresenter = new AuthorViewPresenter(this, _authorDm);
            AuthorView_Load();
        }

        private void AuthorView_Load()
        {
            dtoauthors = GetAuthors();
            
            currentauthoridx = 0;
            PopulateFields(0);
        }
        private void tbxFirstName_TextChanged(object sender, EventArgs e)
        {
            dtoauthors[currentauthoridx].FirstName = tbxFirstName.Text;
        }

        private void tbxLastName_TextChanged(object sender, EventArgs e)
        {
            dtoauthors[currentauthoridx].LastName = tbxLastName.Text;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            PopulateFields(0);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            currentauthoridx = currentauthoridx - 1;
            PopulateFields(currentauthoridx);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            currentauthoridx = currentauthoridx + 1;
            PopulateFields(currentauthoridx);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            PopulateFields(dtoauthors.Count - 1);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
           
            AuthorId = 0;
            FirstName = "";
            LastName = "";
            lblAuthorID.Text = "000";
            tbxFirstName.Text = "";
            tbxLastName.Text = "";
            btnSend.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            AuthorId = int.Parse(lblAuthorID.Text);
            FirstName =   dtoauthors[currentauthoridx].FirstName;
            LastName = dtoauthors[currentauthoridx].LastName;
            btnSend.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Send?.Invoke(this, EventArgs.Empty);
            MessageBox.Show(Message, "",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnSend.Enabled = false;

            if (Message.Contains("add"))
            {
                dtoauthors = GetAuthors();
                currentauthoridx = dtoauthors.Count - 1;
                PopulateFields(currentauthoridx);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            AuthorId = 0;
            FirstName = "";
            LastName = "";
            lblAuthorID.Text = "000";
            tbxFirstName.Text = "";
            tbxLastName.Text = "";

            var dto = new DtoAuthor {AuthorId = 0, FirstName = "", LastName = ""};
            dtoauthors.Add(dto);

            currentauthoridx = dtoauthors.Count - 1;

            btnSend.Enabled = false;
            btnDelete.Enabled = false;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Are you sure you want to delete the Author?",
                "Important Question",
                MessageBoxButtons.YesNo);

            if (result1 == DialogResult.No)
                return;

            AuthorId = dtoauthors[currentauthoridx].AuthorId;
            Delete?.Invoke(this, EventArgs.Empty);

            MessageBox.Show(Message, "",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            AuthorView_Load();
            btnSend.Enabled = false;

        }

        private void PopulateFields(int idx)
        {
            if ((idx < 0 || idx > dtoauthors.Count - 1))
            {
                if (idx < 0)
                {
                    currentauthoridx = 0;
                    idx = 0;
                }

                if (idx > dtoauthors.Count - 1)
                {
                    currentauthoridx = dtoauthors.Count - 1;
                    idx = dtoauthors.Count - 1;
                }
            }

            var dto = dtoauthors[idx];
            
            FirstName = dto.FirstName;
            LastName = dto.LastName;

            lblAuthorID.Text = dto.AuthorId.ToString();
            tbxFirstName.Text = dto.FirstName;
            tbxLastName.Text = dto.LastName;
            btnSend.Enabled = false;
            btnDelete.Enabled = true;
        }

        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Message { get; set; }

        public event EventHandler<EventArgs> Send;
        public event EventHandler<EventArgs> Delete;

        public List<DtoAuthor> GetAuthors()
        {
            return mPresenter.GetAuthors();
        }
    }
}

