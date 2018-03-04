using System;

namespace DodoWare.Mvc.Models.Base
{
    public static class InputParser
    {
        public static decimal? ConvertInputStringToDecimal(
            string inputString,
            string inputId,
            string inputName,
            bool isRequired,
            decimal? maxValue,
            decimal? minValue,
            bool mayBeZero,
            bool mayBeNegative,
            bool allowPercent)
        {
            if (string.IsNullOrWhiteSpace(inputString))
            {
                if (isRequired)
                {
                    throw new DwInputException(inputId, $"The input '{inputName}' is required.");
                }
                return null;
            }

            if (allowPercent)
            {
                inputString = inputString.Trim().TrimEnd('%');
            }
            inputString = inputString.Trim();

            decimal d;

            try
            {
                d = decimal.Parse(inputString);
            }
            catch (Exception)
            {
                throw new DwInputException(inputId, $"The value '{inputString}' for input '{inputName}' could not be converted to a decimal number.");
            }

            if (d == 0M && !mayBeZero)
            {
                throw new DwInputException(inputId, $"The value of input '{inputName}' may not be zero.");
            }

            if (d < 0M && !mayBeNegative)
            {
                throw new DwInputException(inputId, $"The value of input '{inputName}' may not be negative.");
            }

            if (maxValue.HasValue && d > maxValue.Value)
            {
                throw new DwInputException(inputId, $"The value of input '{inputName}' may not be greater than {maxValue.Value}.");
            }

            if (minValue.HasValue && d < minValue.Value)
            {
                throw new DwInputException(inputId, $"The value of input '{inputName}' may not be less than {minValue.Value}.");
            }

            return d;
        }

        public static int? ConvertInputStringToInt(
            string inputString,
            string inputId,
            string inputName,
            bool isRequired,
            decimal? maxValue,
            decimal? minValue,
            bool mayBeZero,
            bool mayBeNegative)
        {
            if (string.IsNullOrWhiteSpace(inputString))
            {
                if (isRequired)
                {
                    throw new DwInputException(inputId, $"The input '{inputName}' is required.");
                }
                return null;
            }

            inputString = inputString.Trim();

            int i;

            try
            {
                i = int.Parse(inputString);
            }
            catch (Exception)
            {
                throw new DwInputException(inputId, $"The value '{inputString}' for input '{inputName}' could not be converted to a whole number.");
            }

            if (i == 0 && !mayBeZero)
            {
                throw new DwInputException(inputId, $"The value of input '{inputName}' must not be zero.");
            }

            if (i < 0 && !mayBeNegative)
            {
                throw new DwInputException(inputId, $"The value of input '{inputName}' must not be negative.");
            }

            if (maxValue.HasValue && i > maxValue.Value)
            {
                throw new DwInputException(inputId, $"The value of input '{inputName}' must not be greater than {maxValue.Value}.");
            }

            if (minValue.HasValue && i < minValue.Value)
            {
                throw new DwInputException(inputId, $"The value of input '{inputName}' must not be less than {minValue.Value}.");
            }

            return i;
        }
    }
}
