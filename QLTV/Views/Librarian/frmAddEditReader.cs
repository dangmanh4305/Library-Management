using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using QLTV.Controllers;
using QLTV.Models;

namespace QLTV.Views.Librarian
{
    public partial class frmAddEditReader : Form
    {
        private readonly ReaderController _controller;
        private Reader _current;
        private bool _isEdit;

        public frmAddEditReader()
        {
            InitializeComponent();
            _controller = new ReaderController();

            // Wire controls
            btnSave.Click += BtnSave_Click;
            btnReset.Click += BtnReset_Click;
            btnX.Click += (s, e) => this.Close();

            // default mode is Add
            PrepareForAdd();
        }

        public void PrepareForAdd()
        {
            _isEdit = false;
            _current = null;
            lbAdd.Visible = true;
            lbEdit.Visible = false;
            txtReadID.Text = string.Empty;
            txtReadID.Enabled = false;
            ClearInputs();
        }

        public void LoadReaderForEdit(int readerId)
        {
            _isEdit = true;
            lbAdd.Visible = false;
            lbEdit.Visible = true;
            txtReadID.Enabled = false;

            _current = _controller.GetReaderById(readerId);
            if (_current == null)
            {
                MessageBox.Show("Không tìm thấy độc giả.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtReadID.Text = _current.ReaderID.ToString();
            txtFullname.Text = _current.FullName;
            txtPhone.Text = _current.Phone;
            txtEmail.Text = _current.Email;
            txtCardExpiryDate.Text = _current.CardExpiryDate?.ToString("yyyy-MM-dd") ?? string.Empty;
            txtStatus.Text = _current.Status;
        }

        private void ClearInputs()
        {
            txtFullname.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtCardExpiryDate.Text = string.Empty;
            txtStatus.Text = "Active";
        }

        private bool ValidateInputs(out string errorMessage)
        {
            errorMessage = null;

            var fullName = txtFullname.Text?.Trim();
            var phone = txtPhone.Text?.Trim();
            var email = txtEmail.Text?.Trim();
            var cardExpiry = txtCardExpiryDate.Text?.Trim();
            var status = txtStatus.Text?.Trim();

            // FullName: required
            if (string.IsNullOrWhiteSpace(fullName))
            {
                errorMessage = "Họ tên không được để trống.";
                txtFullname.Focus();
                return false;
            }

            // Phone: optional but if provided must be digits and reasonable length (7-15)
            if (!string.IsNullOrWhiteSpace(phone))
            {
                var phoneDigits = Regex.Replace(phone, @"\D", "");
                if (phoneDigits.Length != 10)
                {
                    errorMessage = "Số điện thoại không hợp lệ. Vui lòng nhập đúng  10 chữ số.";
                    txtPhone.Focus();
                    return false;
                }
            }

            // Email: optional but if provided validate format (simple regex)
            if (!string.IsNullOrWhiteSpace(email))
            {
                var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                if (!Regex.IsMatch(email, emailPattern))
                {
                    errorMessage = "Email không hợp lệ.";
                    txtEmail.Focus();
                    return false;
                }
            }

            // CardExpiryDate: optional but if provided must be a valid date and not in the past
            if (!string.IsNullOrWhiteSpace(cardExpiry))
            {
                DateTime dt;
                if (!DateTime.TryParse(cardExpiry, out dt))
                {
                    errorMessage = "Ngày hạn thẻ không hợp lệ. Định dạng hợp lệ: yyyy-MM-dd hoặc dạng ngày hợp lệ khác.";
                    txtCardExpiryDate.Focus();
                    return false;
                }
                // allow same day or future
                if (dt.Date < DateTime.Today)
                {
                    errorMessage = "Ngày hạn thẻ phải bằng hoặc sau ngày hiện tại.";
                    txtCardExpiryDate.Focus();
                    return false;
                }
            }

            // Status: optional but normalize and restrict to known values if provided
            if (!string.IsNullOrWhiteSpace(status))
            {
                var s = status.Trim().ToLowerInvariant();
                if (s != "active" && s != "expired" && s != "suspended")
                {
                    errorMessage = "Trạng thái không hợp lệ. Giá trị hợp lệ: Active, Expired, Suspended.";
                    txtStatus.Focus();
                    return false;
                }
            }

            return true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string validationError;
                if (!ValidateInputs(out validationError))
                {
                    MessageBox.Show(validationError, "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var reader = new Reader
                {
                    FullName = txtFullname.Text?.Trim(),
                    Phone = txtPhone.Text?.Trim(),
                    Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                    Status = string.IsNullOrWhiteSpace(txtStatus.Text) ? "Active" : txtStatus.Text.Trim()
                };

                DateTime parsed;
                if (DateTime.TryParse(txtCardExpiryDate.Text?.Trim(), out parsed))
                    reader.CardExpiryDate = parsed;
                else
                    reader.CardExpiryDate = null;

                string error;
                bool ok;
                if (_isEdit)
                {
                    // ensure ReaderID is set
                    if (_current != null)
                        reader.ReaderID = _current.ReaderID;
                    else
                    {
                        int id;
                        if (int.TryParse(txtReadID.Text, out id)) reader.ReaderID = id;
                    }

                    ok = _controller.UpdateReader(reader, out error);
                    if (!ok)
                    {
                        MessageBox.Show("Lỗi khi cập nhật độc giả: " + error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    ok = _controller.AddReader(reader, out error);
                    if (!ok)
                    {
                        MessageBox.Show("Lỗi khi thêm độc giả: " + error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu độc giả: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            if (_isEdit && _current != null)
            {
                // reset to original values
                LoadReaderForEdit(_current.ReaderID);
            }
            else
            {
                // clear inputs for add mode
                ClearInputs();
            }
        }

        private void frmAddEditReader_Load(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }
    }
}