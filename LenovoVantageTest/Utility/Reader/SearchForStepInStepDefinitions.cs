using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Utility.Readers
{
    /*Author: Marcus
 * Desc: for NLS , we need to search for required functions in StepDefinitions.
 */
    class SearchForStepInStepDefinitions
    {
        static List<System.Type> registeredStepDefinitions;
        static List<Tuple<MethodInfo, Type, object>> registeredSteps;

        static List<System.Type> RegisteredStepDefinitions
        {
            get
            {
                if (registeredStepDefinitions == null)
                {
                    registeredStepDefinitions = GetTypesWithBindingAttribute();
                }
                return registeredStepDefinitions;
            }
        }

        public static List<Tuple<MethodInfo, Type, object>> RegisteredSteps
        {
            get
            {
                if (registeredSteps == null)
                {
                    registeredSteps = GetMethosWithStepDefinitionAttribute();
                }
                return registeredSteps;

            }
        }

        static List<System.Type> GetTypesWithBindingAttribute()
        {
            List<System.Type> result = new List<System.Type>();
            foreach (System.Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (type.GetCustomAttributes(typeof(BindingAttribute), true).Length > 0)
                {
                    result.Add(type);
                }
            }
            return result;
        }
        static List<Tuple<MethodInfo, Type, object>> GetMethosWithStepDefinitionAttribute()
        {
            List<Tuple<MethodInfo, Type, object>> result = new List<Tuple<MethodInfo, Type, object>>();
            foreach (Type aStepDefinition in RegisteredStepDefinitions)
            {
                object singleTon = aStepDefinition.GetProperty("instance")?.GetValue(null, null);
                foreach (MethodInfo aMethod in aStepDefinition.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static))
                {

                    string xx = aMethod.Name; //for debug only
                    //System.Diagnostics.Debug.WriteLine(xx);
                    List<StepDefinitionBaseAttribute> stepAttributes = aMethod.GetCustomAttributes<StepDefinitionBaseAttribute>().ToList();
                    if (stepAttributes != null && stepAttributes.Count > 0)
                    {
                        result.Add(new Tuple<MethodInfo, Type, object>(aMethod, aStepDefinition, singleTon));
                    }
                }
            }
            return result;
        }
    }

}