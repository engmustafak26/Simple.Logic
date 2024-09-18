using Newtonsoft.Json;
using Simple.Logic.Shared;

namespace Simple.logic.Demo
{
    public partial class Program
    {
        static void Main(string[] args)
        {

            #region example 1 (bill)
            var billManager = new BillManager();
            string billJson = @"{ id:1,customer:'Mustafa', isCompleted: true}";
            // if id is == 0, it is new, else update
            // if isComplete == true, archive it

            {
                Console.WriteLine("--- Start 'Bill' UseCase Normal Flow ---");


                SequentialFlower<Bill> flower = new();
                SF
                .Flow("ParseBillJson", () =>
                {
                    Console.WriteLine("Parse Json");
                    var bill = JsonConvert.DeserializeObject<Bill?>(billJson);
                    return flower.Success(bill);
                })
                .Flow("AddIfNew", () =>
                {

                    if (billManager.Find(flower.Value.Id) is null)
                    {
                        billManager.Add(flower.Value);
                        flower.MethodOutput = true;
                    }
                    else
                    {
                        flower.MethodOutput = false;
                    }
                    return flower;

                })
                .Flow("UpdateIfExist", C._(() =>
                {
                    if (flower.MethodOutput is false)
                    {
                        billManager.Update(flower.Value);
                    }
                    return flower;
                }))
                .Flow("CheckForCompletetion", () =>
                {
                    if (flower.Value.IsBillCompleted())
                    {
                        flower.MethodOutput = true;
                    }
                    return flower;
                })
                .Flow("ArchiveIfComplete", () =>
                {
                    if (flower.MethodOutput is true)
                    {
                        billManager.Archive(flower.Value);
                    }
                    return flower;
                })
                .Flow("SaveToDb", () =>
                {
                    billManager.SaveToDb(flower.Value);
                    return flower.Return();
                });

                Console.WriteLine("\r\n--- End 'Bill' UseCase ---");
            }
            //////////////////////////////////////////////////////////////////////////////////
            {
                Console.WriteLine("\r\n--- Start 'Bill' UseCase Chaos Flow ---");

                SequentialFlower<Bill> flower = new();
                SF
                .Flow("SaveToDb", C._(() =>
                {
                    billManager.SaveToDb(flower.Value);
                    return flower.Return();
                })
                .Decorate(
                    pre: () => Decorator
                    .Group(
                        body: () => SF
                                .Flow("AddIfNew", C._(() =>
                                {
                                    if (billManager.Find(flower.Value.Id) is null)
                                    {
                                        billManager.Add(flower.Value);
                                        flower.MethodOutput = true;
                                    }
                                    else
                                    {
                                        flower.MethodOutput = false;
                                    }
                                    return flower;

                                })
                                .Decorate(
                                    post: () => SF
                                .Flow("UpdateIfExists", () =>
                                {
                                    if (flower.MethodOutput is false)
                                    {
                                        billManager.Update(flower.Value);
                                    }
                                    return flower;

                                }))),

                        pre: () => SF
                                .Flow("parseBillJsonString", () =>
                        {
                            Console.WriteLine("Parse Json");
                            var bill = JsonConvert.DeserializeObject<Bill?>(billJson);
                            return flower.Success(bill);

                        }),

                        post: () => SF
                                .Flow("ArchiveIfComplete", C._(() =>
                        {

                            if (flower.MethodOutput is true)
                                billManager.Archive(flower.Value);

                            return flower;

                        })
                        .Decorate(
                            pre: () => SF
                        .Flow("checkIfComplete", () =>
                        {

                            flower.MethodOutput = flower.Value.IsBillCompleted();

                            return flower;

                        })))

                          )()));


                Console.WriteLine("\r\n--- End 'Bill' UseCase ---");
            }

            #endregion
        }




    }



}
