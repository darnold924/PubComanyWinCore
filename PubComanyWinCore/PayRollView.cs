using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PubCompanyWinCore.IView;
using PubCompanyWinCore.Presenters;
using BLL;
using Entities;
using Exception = System.Exception;

namespace PubCompanyWinCore
{
    public partial class PayRollView : Form, IPayRollView
    {
        private PayRollViewPresenter mPresenter;
        private IPayRollDM _payRollDm;
        private IAuthorDM _authorDm;
        private List<DtoAuthor> dtoauthors = new List<DtoAuthor>();
        private int currentauthoridx;

        public PayRollView(IPayRollDM payRollDm, IAuthorDM authorDm)
        {
            _payRollDm = payRollDm;
            _authorDm = authorDm;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            mPresenter = new PayRollViewPresenter(this, _payRollDm, _authorDm);
            PayRollView_Load();
        }

        private void PayRollView_Load()
        {
            var dtos = GetAuthors();
            cbxAuthor.ValueMember = "AuthorId";
            cbxAuthor.DisplayMember = "FirstName";
            cbxAuthor.DataSource = dtos;
            dtoauthors = dtos.ToList();

            if (dtos.Count > 0)
            {
                PopulateFields(0);
                currentauthoridx = 0;
            }
        }

        private void btnFrist_Click(object sender, EventArgs e)
        {
            PopulateFields(0);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            currentauthoridx = currentauthoridx -1; 
            PopulateFields(currentauthoridx);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            currentauthoridx = currentauthoridx + 1;
            PopulateFields(currentauthoridx);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            PopulateFields(dtoauthors.Count -1);
        }

        private void cbxAuthor_SelectedIndexChanged(object sender, EventArgs e)
        {
            AuthorId = (int) this.cbxAuthor.SelectedValue;
            dtoauthors = GetAuthors();
            var dto = FindPayRollByAuthorId(AuthorId);
            PayrollId = dto.PayrollId;
            Salary = dto.Salary;
            currentauthoridx = dtoauthors.FindIndex(a => a.AuthorId == AuthorId);

            PopulateFields(currentauthoridx);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var dto = FindPayRollByAuthorId(AuthorId);

            if (dto.AuthorId == 0)
            {
                Add?.Invoke(this, EventArgs.Empty);

                if (Message != "")
                {
                    MessageBox.Show(Message, "",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("There is payroll record for the author.", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UPdate?.Invoke(this, EventArgs.Empty);

            MessageBox.Show(Message, "",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete?.Invoke(this, EventArgs.Empty);
            currentauthoridx = dtoauthors.FindIndex(a => a.AuthorId == AuthorId);
            PopulateFields(currentauthoridx);

            MessageBox.Show( Message, "",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PayRollView_FormClosing(object sender, FormClosingEventArgs e)
        {
           // throw new NotImplementedException();
        }
        private void nudSalary_ValueChanged(object sender, EventArgs e)
        {
            Salary = (int?) nudSalary.Value;
        }

        private void PopulateFields(int idx)
        {
            if ((idx < 0 || idx > dtoauthors.Count -1))
            {
                if (idx < 0)
                {
                    currentauthoridx = 0;
                    idx = 0;
                }

                if (idx > dtoauthors.Count -1)
                {
                    currentauthoridx = dtoauthors.Count -1;
                    idx = dtoauthors.Count -1;
                }
            }
   
            cbxAuthor.SelectedValue = dtoauthors[idx].AuthorId;
            var dtopayroll = FindPayRollByAuthorId(dtoauthors[idx].AuthorId);
            lblPayrollID.Text = dtopayroll.PayrollId.ToString();
            nudSalary.Value = (decimal)dtopayroll.Salary;

            if (dtopayroll.PayrollId > 0)
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                btnAdd.Enabled = true;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                nudSalary.Value = 0;
            }
        }

        #region IPayRollView Members
        public int PayrollId { get; set; }
        public int AuthorId { get; set; }
        public int? Salary { get; set; }
        public string Message { get; set; }

        public List<DtoAuthor> GetAuthors()
        {
            return mPresenter.GetAuthors();
        }

        public DtoPayRoll FindPayRollByAuthorId(int id)
        {
            return mPresenter.FindPayRollByAuthorId(id);
        }

        public event EventHandler<EventArgs> Add;
        public event EventHandler<EventArgs> UPdate;
        public event EventHandler<EventArgs> Delete;
        #endregion
        
    }

}
