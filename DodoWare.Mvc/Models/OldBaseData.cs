using DodoWare.Mvc.Models.Base;
using System;
using System.Web;

namespace DodoWare.Mvc.Models
{
    public abstract class OldBaseData
    {
        /// <summary>
        /// Exception message for any exceptions caused by user input.
        /// </summary>
        public string InputErrorMessage { get; set; }

        /// <summary>
        /// Exception message for any exceptions caused by application logic problems (bugs).
        /// </summary>
        public string LogicErrorMessage { get; set; }

        /// <summary>
        /// The ID corresponding to an input that caused an input error.
        /// </summary>
        public string InputErrorId { get; set; }

        /// <summary>
        /// A warning means the calcualtion completed but produced unexpected results.
        /// </summary>
        public string WarningMessage { get; set; }

        /// <summary>
        /// The total count of numbers allowed for this set of number data.
        /// </summary>
        public int TotalCount { get; }

        /// <summary>
        /// The count of numbers expected to be input for this set of number data.
        /// If less than <@see cref="TotalCount"/>, then the difference is assumed
        /// to be the number of values to be calculated.
        /// </summary>
        public int InputCount { get; }

        /// <summary>
        /// Raw input data, from command-line arguments, or form fields, or some other
        /// source of user input.  The <see cref="string.IsNullOrWhiteSpace(string)"/>
        /// function is used to determine if a value was input or not.
        /// </summary>
        public string[] StringData { get; }

        /// <summary>   
        /// Contains converted input data, or calculation results, for calculations
        /// expecting floating-point input data.
        /// </summary>
        public double[] DoubleData { get; }

        /// <summary>
        /// Contains converted input data, or calculation results, for calculations
        /// expecting integer input data.
        /// </summary>
        public int[] IntData { get; }

        /// <summary>
        /// Shortcut for checking whether the string value with ID 'A' is set.
        /// </summary>
        /// <returns></returns>
        public bool HasA()
        {
            return string.IsNullOrWhiteSpace(As);
        }

        /// <summary>
        /// Shortcut for checking whether the string value with ID 'B' is set.
        /// </summary>
        /// <returns></returns>
        public bool HasB()
        {
            return string.IsNullOrWhiteSpace(Bs);
        }

        /// <summary>
        /// Shortcut for checking whether the string value with ID 'C' is set.
        /// </summary>
        /// <returns></returns>
        public bool HasC()
        {
            return string.IsNullOrWhiteSpace(Cs);
        }

        /// <summary>
        /// Shortcut for checking whether the string value with ID 'D' is set.
        /// </summary>
        /// <returns></returns>
        public bool HasD()
        {
            return string.IsNullOrWhiteSpace(Ds);
        }

        /// <summary>
        /// Shortcut for getting/setting the string value with ID 'A'.
        /// </summary>
        public string As
        {
            get => StringData[GetIndex('A')];
            set => StringData[GetIndex('A')] = value;
        }

        /// <summary>
        /// Shortcut for getting/setting the string value with ID 'B'.
        /// </summary>
        public string Bs
        {
            get => StringData[GetIndex('B')];
            set => StringData[GetIndex('B')] = value;
        }

        /// <summary>
        /// Shortcut for getting/setting the string value with ID 'C'.
        /// </summary>
        public string Cs
        {
            get => StringData[GetIndex('C')];
            set => StringData[GetIndex('C')] = value;
        }

        /// <summary>
        /// Shortcut for getting/setting the string value with ID 'D'.
        /// </summary>
        public string Ds
        {
            get => StringData[GetIndex('D')];
            set => StringData[GetIndex('D')] = value;
        }

        /// <summary>
        /// Shortcut for getting/setting the double value with ID 'A'.
        /// </summary>
        public double Ad
        {
            get => DoubleData[GetIndex('A')];
            set => DoubleData[GetIndex('A')] = value;
        }

        /// <summary>
        /// Shortcut for getting/setting the double value with ID 'B'.
        /// </summary>
        public double Bd
        {
            get => DoubleData[GetIndex('B')];
            set => DoubleData[GetIndex('B')] = value;
        }

        /// <summary>
        /// Shortcut for getting/setting the double value with ID 'C'.
        /// </summary>
        public double Cd
        {
            get => DoubleData[GetIndex('C')];
            set => DoubleData[GetIndex('C')] = value;
        }

        /// <summary>
        /// Shortcut for getting/setting the double value with ID 'D'.
        /// </summary>
        public double Dd
        {
            get => DoubleData[GetIndex('D')];
            set => DoubleData[GetIndex('D')] = value;
        }

        /// <summary>
        /// Shortcut for getting/setting the int value with ID 'A'.
        /// </summary>
        public int Ai
        {
            get => IntData[GetIndex('A')];
            set => IntData[GetIndex('A')] = value;
        }

        /// <summary>
        /// Shortcut for getting/setting the int value with ID 'B'.
        /// </summary>
        public int Bi
        {
            get => IntData[GetIndex('B')];
            set => IntData[GetIndex('B')] = value;
        }

        /// <summary>
        /// Shortcut for getting/setting the int value with ID 'C'.
        /// </summary>
        public int Ci
        {
            get => IntData[GetIndex('C')];
            set => IntData[GetIndex('C')] = value;
        }

        /// <summary>
        /// Shortcut for getting/setting the int value with ID 'D'.
        /// </summary>
        public int Di
        {
            get => IntData[GetIndex('D')];
            set => IntData[GetIndex('D')] = value;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="totalCount">
        /// The total number of numbers in this data set.
        /// </param>
        /// <param name="inputCount">
        /// The number of numbers which are expected to be input for a particular calculation.
        /// </param>
        public OldBaseData(int totalCount, int inputCount)
        {
            TotalCount = totalCount;
            InputCount = inputCount;
            StringData = new string[totalCount];
            DoubleData = new double[totalCount];
            IntData = new int[totalCount];
        }

        /// <summary>
        /// Private helper method to covert a string to an index, to support common use cases,
        /// of looking up values by string labels "A", "B", "C", etc., instead of by numerical index.
        /// </summary>
        /// <param name="id">
        /// The ID.  Must contain only a single character between 'A' and ('A' + <see cref="TotalCount"/>).
        /// </param>
        /// <returns>
        /// The corresponding index into the data arrays.
        /// </returns>
        private int GetIndex(String id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new DwLogicException("An ID was expected, but was not set.");
            }

            if (id.Length > 1)
            {
                throw new DwLogicException($"The ID '{id}' is invalid.  It should only contain a single character.");
            }

            return GetIndex(id[0]);
        }

        /// <summary>
        /// Private helper method to covert a char to an index, to support common use cases,
        /// of looking up values by labels 'A', 'B', 'C', etc., instead of by numerical index.
        /// </summary>
        /// <param name="id">
        /// The ID.  Must be between 'A' and ('A' + <see cref="TotalCount"/>).
        /// </param>
        /// <returns>
        /// The corresponding index into the data arrays.
        /// </returns>
        private int GetIndex(char id)
        {
            char max = (char)('A' + TotalCount - 1);

            if (id < 'A' || id > max)
            {
                throw new DwLogicException($"The ID '{id}' is invalid.  It should be in the range A-{max}.");
            }

            return id - 'A';
        }

        /// <summary>
        /// Get user input submitted via HTML form.  This updates the <see cref="StringData"/>
        /// but does not touch the other data arrays.
        /// </summary>
        /// <param name="request">
        /// The <see cref="HttpRequestBase"/> object containing form data.
        /// </param>
        public void GetInput(HttpRequestBase request)
        {
            for (var i = 0; i < TotalCount; i++)
            {
                string id = ((char)('A' + i)).ToString();
                string value = request[id];
                StringData[i] = (string.IsNullOrWhiteSpace(value)) ? null : value;
            }
        }

        /// <summary>
        /// Get any extra or additional user input, beyond the numerical input managed by this class.
        /// </summary>
        /// <param name="request">
        /// The <see cref="HttpRequestBase"/> object containing form data.
        /// </param>
        protected abstract void GetExtraInput(HttpRequestBase request);

        /// <summary>
        /// For each entry in the <see cref="StringData"/>, convert to double then stash
        /// it in the <see cref="DoubleData"/>.  This method will throw an exception if
        /// a string entry can't be converted.  But the user input count isn't checked.
        /// </summary>
        internal void InputToDouble()
        {
            for (var i = 0; i < TotalCount; i++)
            {
                string id = ((char)('A' + i)).ToString();
                string value = StringData[i];
                if (!string.IsNullOrWhiteSpace(value))
                {
                    try
                    {
                        DoubleData[i] = double.Parse(value);
                    }
                    catch (Exception)
                    {
                        throw new DwInputException(id, $"The value '{value}' for '{id}' is not a proper number.  Please check the input value and try again.");
                    }
                }
            }
        }

        /// <summary>
        /// For each entry in the <see cref="StringData"/>, convert to int then stash
        /// it in the <see cref="IntData"/>.  This method will throw an exception if
        /// a string entry can't be converted.  But the user input count isn't checked.
        /// </summary>
        internal void InputToInt()
        {
            for (var i = 0; i < TotalCount; i++)
            {
                string id = ((char)('A' + i)).ToString();
                string value = StringData[i];
                if (!string.IsNullOrWhiteSpace(value))
                {
                    try
                    {
                        IntData[i] = int.Parse(value);
                    }
                    catch (Exception)
                    {
                        throw new DwInputException(id, $"The value '{value}' for '{id}' is not a proper whole number.  Please check the input value and try again.");
                    }
                }
            }
        }

        /// <summary>
        /// Check the count of user data input, to make sure it matches what is expected for a particular calculation.
        /// </summary>
        internal void CheckInputCount()
        {
            int count = 0;
            for (var i = 0; i < TotalCount; i++)
            {
                if (!string.IsNullOrWhiteSpace(StringData[i]))
                {
                    count++;
                }
            }
            string checkCountErrorMessage = GetCountErrorMessage(count);
            if (checkCountErrorMessage != null)
            {
                throw new DwInputException(null, checkCountErrorMessage);
            }
        }

        /// <summary>
        /// Helper method to get an appropriate message if the input count doesn't match expectations.
        /// </summary>
        /// <param name="count">
        /// The input count.
        /// </param>
        /// <returns>
        /// An input count error message.  Null means the input count is correct, and there is no error.
        /// </returns>
        private string GetCountErrorMessage(int count)
        {
            if (count == InputCount)
            {
                return null;
            }
            else if (count == 0)
            {
                if (InputCount == 1)
                {
                    if (TotalCount == 1) return "The value was not entered.  Please enter a value and try again.";
                    if (TotalCount == 2) return "No values were entered.  Please enter one value.  The second value will be calculated.";
                    if (TotalCount > 2) return "No values were entered.  Please enter one value.  The remaining values will be calculated.";
                }
                else if (InputCount == 2)
                {
                    if (TotalCount == 2) return ("No values were entered.  Both values are required for this calculation.");
                    if (TotalCount == 3) return ("No values were entered.  Please enter any two values.  The third value will be calculated.");
                    if (TotalCount > 3) return ("No values were entered.  Please enter any two values.  The remaining values will be calculated.");
                }
                else if (InputCount == 3)
                {
                    if (TotalCount == 3) return ("No values were entered.  All three values are required for this calculation.");
                    if (TotalCount == 4) return ("No values were entered.  Please enter any three values.  The fourth value will be calculated.");
                }
                else if (InputCount == 4)
                {
                    if (TotalCount == 4) return ("No values were entered.  All four values are required for this calculation.");
                }
            }
            else if (count == 1)
            {
                if (InputCount == 2)
                {
                    if (TotalCount == 2) return ("Only one value was entered.  Both values are required for this calculation.");
                    if (TotalCount == 3) return ("Only one value was entered.  Please enter any two values.  The third value will be calculated.");
                    if (TotalCount > 3) return ("Only one value was entered.  Please enter any two values.  The remaining values will be calculated.");
                }
                else if (InputCount == 3)
                {
                    if (TotalCount == 3) return ("Only one value was entered.  All three values are required for this calculation.");
                    if (TotalCount == 4) return ("Only one value was entered.  Please enter any three values.  The fourth value will be calculated.");
                }
                else if (InputCount == 4)
                {
                    if (TotalCount == 4) return ("Only one value was entered.  All four values are required for this calculation.");
                }
            }
            else if (count == 2)
            {
                if (InputCount == 3)
                {
                    if (TotalCount == 3) return ("Only two values were entered.  All three values are required for this calculation.");
                    if (TotalCount == 4) return ("Only two values were entered.  Please enter any three values.  The fourth value will be calculated.");
                }
                else if (InputCount == 4)
                {
                    if (TotalCount == 4) return ("Only two values were entered.  All four values are required for this calculation.");
                }
            }
            else if (count == 3)
            {
                if (InputCount == 4)
                {
                    if (TotalCount == 4) return ("Only three values were entered.  All four values are required for this calculation.");
                }
            }

            throw new DwLogicException($"Failed to handle count={count}, InputCount={InputCount}, TotalCount={TotalCount}.  Please report this as a bug.");
        }

        public static string GetInputAsString(HttpRequestBase request, string name)
        {
            string value = request[name];
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new DwLogicException($"Input '{name}' was not included in the request.");
            }
            return value;
        }

        public static TEnum GetInputAsEnum<TEnum>(HttpRequestBase request, string name)
        {
            string value = GetInputAsString(request, name);
            try
            {
                return (TEnum)System.Enum.Parse(typeof(TEnum), value);
            }
            catch (Exception)
            {
                throw new DwLogicException($"The input '{name}' was set with an invalid value '{value}'.");
            }
        }
    }
}
