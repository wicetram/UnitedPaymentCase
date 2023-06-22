using UnitedPaymentCaseEntity.Dto.Register;

namespace UnitedPaymentCaseWebApi.Business.Abstract
{
    public interface IVerificationService
    {
        bool VerifyTCKN(RegisterRequestDto requestDto);
    }
}
