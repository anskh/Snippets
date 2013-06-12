using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Snippets.Common.DomainObjects.Entities;
using Snippets.Common.DomainObjects.Models;

namespace Snippets.Generics.Extensions
{
    public static class Extensions
    {
        //where TOut : new()

        /// <summary>
        /// Lambda notation version
        /// </summary>
        /// <typeparam name="TIn"></typeparam>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static TOut ConvertUsingLambdaNotation<TIn, TOut>(this TIn obj)  {
            var output = (TOut)Activator.CreateInstance(typeof(TOut));

            var typeIn = typeof(TIn);
            var typeOut = typeof(TOut);

            var propsIn = typeIn.GetProperties();
            var propsOut = typeOut.GetProperties();

            var props = propsIn.Join(propsOut, 
                                     i => i.Name, 
                                     o => o.Name, 
                                     (a, b) => new { PropIn = a, PropOut = b } ).ToList();
            

            foreach (var prop in props) {
                var val = prop.PropIn.GetValue(obj, null);
                prop.PropOut.SetValue(output, val, null);
            }           

            return output;
        }

        /// <summary>
        /// Linq Query
        /// </summary>
        /// <remarks>
        /// http://stackoverflow.com/questions/8846992/copy-the-content-of-one-collection-to-another-using-a-generic-function
        /// </remarks>
        /// <typeparam name="TIn"></typeparam>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static TOut ConvertUsingLinqQuery<TIn, TOut>(this TIn obj) {
            var output = (TOut)Activator.CreateInstance(typeof(TOut));

            var typeIn = typeof(TIn);
            var typeOut = typeof(TOut);

            var propsIn = typeIn.GetProperties();
            var propsOut = typeOut.GetProperties();

            var props = from propIn in propsIn
                             join propOut in propsOut
                             on propIn.Name equals propOut.Name
                             select new { PropIn = propIn, PropOut = propOut };

            foreach (var prop in props) {
                var val = prop.PropIn.GetValue(obj, null);
                prop.PropOut.SetValue(output, val, null);
            }

            return output;
        }

        public static TOut ConvertUsingMagic<TIn, TOut>(this TIn obj) {
            var output = (TOut)Activator.CreateInstance(typeof(TOut));

            var typeIn = typeof(TIn);
            var typeOut = typeof(TOut);

            var propsIn = typeIn.GetProperties(BindingFlags.Public);
            var propsOut = typeOut.GetProperties(BindingFlags.Public);

            foreach (var prop in propsIn) {
                var name = prop.Name;
                if (typeOut.GetProperty(name) != null) {
                    var value = prop.GetValue(typeIn);

                }

            }
            return output;
        }
    }
}
