using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace LayoutRecord
{
    public enum align {
        right,
        left
    }

    public enum type {
        StringValue,
        NumericValue
    }

    public class FieldProp
    {

        public string Description { get; set; }
        public int Lenght { get; set; }

        public align AlignValue;
        public type TypeValue;

        public bool FieldResettable;

        public string stringValue { get; set; }
        public string DefaultStringValue;

        public decimal numericValue { get; set; }
        public string FormatNumericValue;
        public string NumberDecimalSeparator;


        public string StringValue {
            get { return stringValue; }
            set
            {
                var stringAlign = AlignValue == align.right 
                                                ? "{0," + Lenght.ToString() + "}" 
                                                : "{0,-" + Lenght.ToString() + "}";

                stringValue = string.Format(stringAlign, value);
            }
        }
        public void ResetStringField() {
                StringValue = DefaultStringValue;
            }

        public decimal NumericValue
        {
            get { return numericValue; }
            set
            {

                numericValue = value;
                if (NumberDecimalSeparator != null)
                {
                    var nf = new CultureInfo("it-IT", false).NumberFormat;
                    nf.NumberDecimalSeparator = NumberDecimalSeparator;
                    StringValue = NumericValue.ToString(FormatNumericValue, nf);
                }
                else
                {
                    StringValue = NumericValue.ToString(FormatNumericValue);
                }
            }
        }

        public void ResetNumericField()
        {
            NumericValue = 0;
        }



    }
}
