using Microsoft.Xrm.Sdk;
using System;

namespace CPM.ReporteAuditoria.DataLayer.ExtensionMethods
{
    public static class ExtensionMethods
    {
        public static int GetIntValue(this Entity target, string nombreCampo)
        {
            if (target != default(Entity) && target.Contains(nombreCampo) && target.Attributes[nombreCampo] != null)
                return target.GetAttributeValue<int>(nombreCampo);

            return 0;
        }

        public static string GetStringValue(this Entity target, string nombreCampo)
        {
            if (target != default(Entity) && target.Contains(nombreCampo) && target.Attributes[nombreCampo] != null)
                return target.GetAttributeValue<string>(nombreCampo);

            return string.Empty;
        }

        public static decimal GetDecimalValue(this Entity target, string nombreCampo, bool esValorMoney = true)
        {
            decimal value = 0.0m;
            if (target != default(Entity) && target.Contains(nombreCampo))
            {
                if (esValorMoney)
                    return value = target.Attributes[nombreCampo] != null ? ((Money)target.Attributes[nombreCampo]).Value : value;
                else
                    return value = target.Attributes[nombreCampo] != null ? (decimal)target.Attributes[nombreCampo] : value;
            }
            else return value;
        }

        public static bool GetBoolValue(this Entity target, string nombreCampo)
        {
            if (target != default(Entity) && target.Contains(nombreCampo) && target.Attributes[nombreCampo] != null)
                return (bool)target.GetAttributeValue<bool>(nombreCampo);
            return false;
        }

        public static int GetOptionSetValue(this Entity target, string nombreCampo)
        {
            if (target != null && target.Contains(nombreCampo) && target.Attributes[nombreCampo] != null)
                return target.GetAttributeValue<OptionSetValue>(nombreCampo).Value;
            return -1;
        }
        public static EntityReference GetLookUpValue(this Entity target, Entity image, string nombreCampo)
        {
            if (target.Contains(nombreCampo) && target.Attributes[nombreCampo] != null)
                return target.GetAttributeValue<EntityReference>(nombreCampo);
            else if (image.Contains(nombreCampo) && image.Attributes[nombreCampo] != null)
                return image.GetAttributeValue<EntityReference>(nombreCampo);
            else
                return null;
        }
        public static Guid GetGuidValue(this Entity target, string nombreCampo, bool EsEntityReference = true)
        {
            Guid id = default(Guid);
            if (target.Contains(nombreCampo))
                if (EsEntityReference)
                    return id = target.Attributes[nombreCampo] == null ? Guid.Empty : ((EntityReference)target.Attributes[nombreCampo]).Id;
                else
                    return id = target.Attributes[nombreCampo] == null ? Guid.Empty : (Guid)target.Attributes[nombreCampo];

            else
                return Guid.Empty;
        }


        public static DateTime GetDateTimeValue(this Entity target, string nombreCampo)
        {
            if (target != null && target.Contains(nombreCampo) && target[nombreCampo] != null)
                return TimeZoneInfo.ConvertTime(target.GetAttributeValue<DateTime>(nombreCampo), TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time (Mexico)"));
            return DateTime.MinValue;
        }

        public static string GetAliasedStringValue(this Entity target, string nombreCampoConAlias)
        {
            if (target != default(Entity) && target.Contains(nombreCampoConAlias))
            {
                return (string)((AliasedValue)target[nombreCampoConAlias]).Value;
            }
            else return string.Empty;
        }

        public static decimal GetAliasedMoneyValue(this Entity target, string nombreCampo)
        {
            if (target != null && target.Contains(nombreCampo) && target[nombreCampo] != null)
                if (target.GetAttributeValue<AliasedValue>(nombreCampo).Value != null)
                    return ((Money)(target.GetAttributeValue<AliasedValue>(nombreCampo).Value)).Value;
            return default(decimal);
        }

        public static decimal GetAliasedDecimalValue(this Entity target, string nombreCampo)
        {
            if (target != null && target.Contains(nombreCampo) && target[nombreCampo] != null)
                if (target.GetAttributeValue<AliasedValue>(nombreCampo).Value != null)
                    return ((decimal)(target.GetAttributeValue<AliasedValue>(nombreCampo).Value));
            return default(decimal);
        }

        public static int GetAliasedOptionSetValue(this Entity target, string nombreCampo)
        {
            if (target != null && target.Contains(nombreCampo) && target[nombreCampo] != null)
                if (target.GetAttributeValue<AliasedValue>(nombreCampo).Value != null)
                    return ((OptionSetValue)(target.GetAttributeValue<AliasedValue>(nombreCampo).Value)).Value;
            return default(int);
        }
    }
}
