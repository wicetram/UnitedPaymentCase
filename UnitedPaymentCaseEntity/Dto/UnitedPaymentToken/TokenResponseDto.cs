﻿namespace UnitedPaymentCaseEntity.Dto.UnitedPaymentToken
{
    public class TokenResponseDto
    {
        public bool fail { get; set; }
        public int statusCode { get; set; }
        public Result result { get; set; }
        public int count { get; set; }
        public string errorCode { get; set; }
        public string errorDescription { get; set; }
    }
    public class Result
    {
        public string userId { get; set; }
        public string token { get; set; }
    }
}
