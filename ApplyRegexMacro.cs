using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using JetBrains.ReSharper.Feature.Services.LiveTemplates.Macros;
using JetBrains.ReSharper.Feature.Services.LiveTemplates.Hotspots;

namespace ChrisLaco.ReSharper.Macros
{
    [Macro("applyRegex", ShortDescription = "Replace string matching {#0:pattern} with {#1:string} in {#2:variable}", LongDescription = "Applies regex to replace value in another template variable.")]
    class ApplyRegexMacro : IMacro
    {
        #region IMacro Members

        public string EvaluateQuickResult(IHotspotContext context, IList<string> arguments)
        {
            if (arguments.Count != 3)
            {
                return null;
            }
            else
            {
                try
                {
                    var result = Regex.Replace(arguments[2], arguments[0], arguments[1], RegexOptions.IgnoreCase);

                    return result;
                }
                catch (Exception e)
                {
                    return "<" + e.Message + ">";
                }
            }
        }

        public HotspotItems GetLookupItems(IHotspotContext context, IList<string> arguments)
        {
            return null;
        }

        public string GetPlaceholder()
        {
            return "a";
        }

        public bool HandleExpansion(IHotspotContext context, IList<string> arguments)
        {
            return false;
        }

        public ParameterInfo[] Parameters
        {
            get
            {
                return new[] { new ParameterInfo(ParameterType.String), new ParameterInfo(ParameterType.String), new ParameterInfo(ParameterType.VariableReference) };           
            }
        }

        #endregion
    }
}