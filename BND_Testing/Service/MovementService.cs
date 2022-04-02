using BND_Testing.DBModel.FakeDB;
using BND_Testing.Domain;
using BND_Testing.Dto;
using BND_Testing.Model;
using System;
using System.Threading.Tasks;

namespace BND_Testing.Service
{
    public class MovementService : IMovementService
    {
        private FakeDB _context;
        public MovementService(FakeDB context)
        {
            _context = context;
        }

        public async Task<MovementDto> GetMovements(int productId)
        {
            var prodCustomer = _context.ProductCustomers.Find(productId).Customer.CustomerEmail;
            if (prodCustomer == null) return null;

            ThirdPartyResponse mockThirdPartyResp = new()
            {
                Account = prodCustomer,
                Amount = 1000,
                AccountFrom = "Jane_Account",
                AccountTo = "Joe_Account",
                PageNumber = 10,
                PageSize = 10,
                MovementType = (EnumMovementType)Enum.Parse(typeof(EnumMovementType), "Free"),
            };

            MovementDto movement = Map(mockThirdPartyResp);
            return movement;
        }

        public static MovementDto Map(ThirdPartyResponse thirdPartyResponse) => new()
        {
            PageSize = thirdPartyResponse.PageSize,
            PageNumber = thirdPartyResponse.PageNumber,

            Movements = new()
            {
                Account = thirdPartyResponse.Account,
                Amount = thirdPartyResponse.Amount,
                MovementType = thirdPartyResponse.MovementType,
                AccountFrom = thirdPartyResponse.AccountFrom,
                AccountTo = thirdPartyResponse.AccountTo
            }
        };

    }
}
