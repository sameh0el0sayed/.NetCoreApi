using DotNetCoreApi.Models;
using DotNetCoreApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        VouchersRepository repository = new VouchersRepository();

        #region User
        [HttpGet(Name = "GetAllVoucherPurchasedForUser")]
        public IEnumerable<Voucher> GetAllVoucherPurchasedForUser(int userID)
        {
            return repository.GetAllVoucherPurchasedForUser(userID);
        }
        [HttpPost(Name = "BuyVoucherForUser")]
        public ActionResult<Voucher> BuyVoucherForUser(int voucherId, int userID)
        {
            return repository.BuyVoucherForUser(voucherId, userID);
        }
        #endregion

        #region Admin
        [HttpPost("/{username}/{password}/GetAllVoucher", Name = "GetAllVoucher")]
        public IEnumerable<Voucher> GetAllVoucher(string username, string password)
        {
            return repository.GetAllVoucher(username, password);
        }
        [HttpGet("/{VoucherID}/{username}/{password}/GetVoucherByID", Name = "GetVoucherByID")]
        public IEnumerable<Voucher> GetVoucherByID(int VoucherID, string username, string password)
        {
            return repository.GetVoucherByID(VoucherID, username, password);
        }
        [HttpGet("/{type}/GetVoucherFilterType")]
        public IEnumerable<Voucher> GetVoucherFilterType(int type, string username, string password)
        {
            return repository.GetVoucherFilterType(type, username, password);
        }
        [HttpGet("/{title}/GetVoucherFilterTitle", Name = "GetVoucherFilterTitle")]
        public IEnumerable<Voucher> GetVoucherFilterTitle(string title, string username, string password)
        {
            return repository.GetVoucherFilterTitle(title, username, password);
        }
        [HttpPost("/InsertVoucher", Name = "InsertVoucher")]
        public ActionResult<Voucher> InsertVoucher(Voucher voucher, string username, string password)
        {
            return repository.InsertVoucher(voucher, username, password);
        }
        [HttpPost("/{voucherID}/UpdateVoucher", Name = "UpdateVoucher")]
        public ActionResult<Voucher> UpdateVoucher(int voucherID, Voucher voucher, string username, string password)
        {
            return repository.UpdateVoucher(voucherID, voucher, username, password);
        }
        [HttpPost("/{voucherID}/DeleteVoucher", Name = "DeleteVoucher")]
        public ActionResult<Voucher> DeleteVoucher(int voucherID, string username, string password)
        {
            return repository.DeleteVoucher(voucherID, username, password);
        }

        #endregion  
    }
}
