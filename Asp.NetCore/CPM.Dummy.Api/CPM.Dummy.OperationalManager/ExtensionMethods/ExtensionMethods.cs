using System.Text;

namespace CPM.Dummy.OperationalManager.ExtensionMethods
{
    public static class ExtensionMethods
    {
        public static string Build(this Exception target)
        {
            var message = new StringBuilder();
            while (target != null)
            {
                message.AppendLine(target.Message);
                target = target.InnerException;
            }
            return message.ToString();
        }

    }
}
