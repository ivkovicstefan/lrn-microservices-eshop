﻿namespace Ordering.Domain.ValueObjects
{
    public record Payment
    {
        private const int DefaultCvvLength = 3;
        public string? CardName { get; } = default!;
        public string CardNumber { get; } = default!;
        public string? Expiration { get; } = default!;
        public string Cvv { get; set; } = default!;
        public int PaymentMethod { get; set; }
        protected Payment() { }

        private Payment(string cardName, string cardNumber, string expiration, string cvv,
            int paymentMethod)
        {
            CardName = cardName;
            CardNumber = cardNumber;
            Expiration = expiration;
            Cvv = cvv;
            PaymentMethod = paymentMethod;
        }

        public static Payment Of(string cardName, string cardNumber, string expiration, string cvv,
            int paymentMethod)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(cardName);
            ArgumentException.ThrowIfNullOrWhiteSpace(cardNumber);
            ArgumentException.ThrowIfNullOrWhiteSpace(cvv);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(cvv.Length, DefaultCvvLength);

            return new Payment(cardName, cardNumber, expiration, cvv, paymentMethod);
        }
    }
}