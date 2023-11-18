using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Commands
{
    public class CreateDriverInfoRequest :IRequest<GetDriverResponse>
    {
      

        public CreateDriverInfoRequest DriverRequest { get;}

        public CreateDriverInfoRequest(CreateDriverInfoRequest driverRequest)
        {
            DriverRequest = driverRequest;
        }

        public CreateDriverInfoRequest(CreateDriverRequest driver)
        {
        }
    }
}
