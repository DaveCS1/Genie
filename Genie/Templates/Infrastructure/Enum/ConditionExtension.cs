#region Usings

using Genie.Core.Base.Generating.Concrete;

#endregion

namespace Genie.Core.Templates.Infrastructure.Enum
{
    internal class ConditionExtensionTemplate : GenieTemplate
    {
        public ConditionExtensionTemplate(string path) : base(path)
        {
        }

        public override string Generate()
        {
            L($@"

using System;

namespace {GenerationContext.BaseNamespace}.Infrastructure.Enum
{{
    public enum Condition
    {{
        IsNull,
        IsNotNull,
        Equal,
        NotEqual,
        Less,
        Greater,
        LessEqual,
        GreaterEqual,
        Between,
        Like,
        In
    }}

    public static class ConditionExtension
    {{
        public static string GetString(this Condition e)
        {{
            switch (e)
            {{
                case Condition.IsNull:
                    return ""IS NULL"";
                case Condition.IsNotNull:
                    return ""IS NOT NULL"";
                case Condition.Equal:
                    return ""="";
                case Condition.NotEqual:
                    return ""<>"";
                case Condition.Less:
                    return ""<"";
                case Condition.Greater:
                    return "">"";
                case Condition.LessEqual:
                    return ""<="";
                case Condition.GreaterEqual:
                    return "">="";
                case Condition.Between:
                    return ""BETWEEN"";
                case Condition.Like:
                    return ""LIKE"";
                case Condition.In:
                    return ""IN"";
                default:
                    throw new ArgumentOutOfRangeException(""e"");
            }}
        }}
    }}

    public enum SortAs
    {{
        Asc,
        Desc
    }}
}}
");

            return E();
        }
    }
}