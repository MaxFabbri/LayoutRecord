using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LayoutRecord
{
    public abstract class Layout
    {

        internal string trackDescription;
        protected List<FieldProp> fieldProp = new List<FieldProp>();

        protected void AddField(Action<FieldProp> addField)
        {
            FieldProp fp = new FieldProp();
            addField(fp);
            fieldProp.Add(fp);
        }

        public FieldProp Field(string fieldDescription)
        {
            var fp = fieldProp.FirstOrDefault(x => x.Description == fieldDescription);
            return fp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="forceAllField"></param>
        public void ResetFields(bool forceAllField = false) {
            foreach (var fp in fieldProp)
            {
                if (fp.FieldResettable || forceAllField)
                {
                    if (fp.TypeValue == type.StringValue)
                        fp.ResetStringField();
                    else
                        fp.ResetNumericField();
                }
            }
        }

        
        public override string ToString()
        {
            var tempString = new StringBuilder();
            fieldProp.ForEach(x => tempString.Append(x.StringValue));
            return tempString.ToString();
        }

    }
}
