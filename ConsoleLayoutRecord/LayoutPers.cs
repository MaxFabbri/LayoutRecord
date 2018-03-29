using LayoutRecord;

namespace ConsoleLayoutRecord

{
    class LayoutPers : Layout
    {
        public LayoutPers ()
        {
            AddField(ft => {
                ft.Description = "TRACREC";
                ft.TypeValue = type.StringValue;
                ft.Lenght = 2;
                ft.AlignValue = align.left;
                ft.FieldResettable = false;
                ft.DefaultStringValue = "00";
            });

            AddField(ft => {
                ft.Description = "Field1";
                ft.TypeValue = type.StringValue;
                ft.Lenght = 10;
                ft.AlignValue = align.left;
                ft.FieldResettable = true;
                ft.DefaultStringValue = "Field1";
            });

            AddField(ft =>
            {
                ft.Description = "Field2";
                ft.TypeValue = type.StringValue;
                ft.Lenght = 10;
                ft.AlignValue = align.right;
                ft.FieldResettable = true;
                ft.DefaultStringValue = "Field2";
            });

            AddField(ft =>
            {
                ft.Description = "numericoField";
                ft.TypeValue = type.NumericValue;
                ft.FieldResettable = true;
                //ft.NumberDecimalSeparator = ",";
                ft.FormatNumericValue = "000.00";
            });
            AddField(ft =>
            {
                ft.Description = "CRLF";
                ft.TypeValue = type.StringValue;
                ft.FieldResettable = false;
                ft.DefaultStringValue = "\r\n" ;
            });

        }

    }
}
