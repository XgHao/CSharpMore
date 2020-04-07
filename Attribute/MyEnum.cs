using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttributeDemo
{
    public static class MyEnum
    {
        public enum CRUD
        {
            [Chinese("创建")]
            Create,

            [Chinese("读取")]
            Retrieve,

            [Chinese]
            Update,

            Delete
        }

        public static string GetChinese(this Enum value)
        {
            Type objType = value.GetType();
            Type attrType = typeof(ChineseAttribute);

            FieldInfo field = objType.GetField(value.ToString());

            //1.利用反射找是否有【Chinese】特性
            if (field.IsDefined(attrType))
            {
                ChineseAttribute chinese = field.GetCustomAttribute(attrType) as ChineseAttribute;
                return chinese.Chinese;
            }
            return value.ToString();
        }
    }
}
