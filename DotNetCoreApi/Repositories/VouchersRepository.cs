using DotNetCoreApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreApi.Repositories
{
    public class VouchersRepository : ControllerBase
    {
        Test_dbContext _DbContext;

        UsersRepository usersRepository=new UsersRepository();  

        public VouchersRepository(Test_dbContext DbContext)
        {
            _DbContext = DbContext;

        }
        public VouchersRepository()
        {
            _DbContext = new Test_dbContext();
        }


        public IEnumerable<Voucher> GetAllVoucherPurchasedForUser(int userID)
        {
            var voucher = _DbContext.Vouchers.Where(w => w.UserBuyed == userID).ToList();
            if (voucher is not null)
            {
                return voucher;
            }
            else
            {
                return Enumerable.Empty<Voucher>();
            }
        }
        public ActionResult<Voucher> BuyVoucherForUser(int voucherID, int userID)
        {
            var voucher = _DbContext.Vouchers.Where(w => w.Id == voucherID).FirstOrDefault();
            if (voucher is not null)
            {
                voucher.UserBuyed = userID;

                UpdateVoucherForUser(voucher.Id, voucher);

                return voucher;
            }
            else
            {
                return BadRequest();
            }
        }
        private ActionResult<Voucher> UpdateVoucherForUser(int id, Voucher voucher )
        {
            var MyUpdateVoucher = _DbContext.Vouchers.Where(u => u.Id == id).FirstOrDefault();
            if (MyUpdateVoucher is not null)
            {
              
                MyUpdateVoucher.UserBuyed = voucher.UserBuyed;
                
                _DbContext.Vouchers.Update(MyUpdateVoucher);
                _DbContext.SaveChanges();
                return MyUpdateVoucher;
            }
            else
            {
                return BadRequest();
            }
        }

        #region For Admin
        public IEnumerable<Voucher> GetAllVoucher(string username,string password)
        {
            if (usersRepository.AdminLogin(username,password) is not null)
            {
                var voucher = _DbContext.Vouchers.ToList();
                if (voucher is not null)
                {
                    return voucher;
                }
                else
                {
                    return Enumerable.Empty<Voucher>();
                }
            }
            else
            {
                return Enumerable.Empty<Voucher>();
            }

        }
        public IEnumerable<Voucher> GetVoucherByID(int ID, string username, string password)
        {
            if (usersRepository.AdminLogin(username, password) is not null)
            {

                var voucher = _DbContext.Vouchers.Where(w => w.Id == ID).ToList();
                if (voucher is not null)
                {
                    return voucher;
                }
                else
                {
                    return Enumerable.Empty<Voucher>();
                }
            }
            else
            {
                return Enumerable.Empty<Voucher>();
            }

        }
        public IEnumerable<Voucher> GetVoucherFilterType(int type, string username, string password)
        {
            if (usersRepository.AdminLogin(username, password) is not null)
            {
                var voucher = _DbContext.Vouchers.Where(w => w.Type == type).ToList();
                if (voucher is not null)
                {
                    return voucher;
                }
                else
                {
                    return Enumerable.Empty<Voucher>();
                }
            }
            else
            {
                return Enumerable.Empty<Voucher>();

            }

        }
        public IEnumerable<Voucher> GetVoucherFilterTitle(string title, string username, string password)
        {
            if (usersRepository.AdminLogin(username, password) is not null)
            {
                var voucher = (from v in _DbContext.Vouchers
                               where v.Title.Contains(title)
                               select v).ToList();

                if (voucher is not null)
                {
                    return voucher;
                }
                else
                {
                    return Enumerable.Empty<Voucher>();
                }
            }
            else
            {
                return Enumerable.Empty<Voucher>();

            }

        }
        public ActionResult<Voucher> InsertVoucher(Voucher voucher, string username, string password)
        {
            if (usersRepository.AdminLogin(username, password) is not null)
            {
                try
                {
                    _DbContext.Vouchers.Add(voucher);
                    _DbContext.SaveChanges();
                    return voucher;
                }
                catch (Exception)
                {

                    return BadRequest();
                }
            }
            else
            {
                return BadRequest("NotAdmin");
            }
                
        }
        public ActionResult<Voucher> UpdateVoucher(int id, Voucher voucher, string username, string password)
        {
            if (usersRepository.AdminLogin(username, password) is not null)
            {
                var MyUpdateVoucher = _DbContext.Vouchers.Where(u => u.Id == id).FirstOrDefault();
                if (MyUpdateVoucher is not null)
                {
                    MyUpdateVoucher.Title = voucher.Title;
                    MyUpdateVoucher.Type = voucher.Type;
                    MyUpdateVoucher.Description = voucher.Description;
                    MyUpdateVoucher.UserBuyed = voucher.UserBuyed;
                    MyUpdateVoucher.TimeUsed = voucher.TimeUsed;
                    MyUpdateVoucher.Limit = voucher.Limit;
                    MyUpdateVoucher.Number = voucher.Number;
                    MyUpdateVoucher.Point = voucher.Point;


                    _DbContext.Vouchers.Update(MyUpdateVoucher);
                    _DbContext.SaveChanges();
                    return MyUpdateVoucher;
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest("NotAdmin");

            }
           
        }
        public ActionResult DeleteVoucher(int id, string username, string password)
        {
            if (usersRepository.AdminLogin(username, password) is not null)
            {
                var MyUpdateVoucher = _DbContext.Vouchers.Where(u => u.Id == id).FirstOrDefault();
                if (MyUpdateVoucher is not null)
                {
                    _DbContext.Vouchers.Remove(MyUpdateVoucher);
                    _DbContext.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest("NotAdmin");
            }

        }
        #endregion


        #region comment code
        //public ActionResult GetAllVoucherForUser()
        //{
        //    return BadRequest();
        //}
        #endregion
    }
}
