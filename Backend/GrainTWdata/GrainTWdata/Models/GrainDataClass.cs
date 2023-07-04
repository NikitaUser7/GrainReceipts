using GrainTWdata.DB;
using GrainTWdata.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GrainTWdata.Models
{
    public class GrainDataClass
    {
        public static List<GrainInput> GetData(GetGrainDataArgs args)
        {
            List<GrainInput> data = new List<GrainInput>();
            GrainTwContext db = new GrainTwContext();
            var query = db.TblGrainReceipts.Select(d => new GrainInput
            {
                Amount = d.Amount,
                BranchId = d.BranchId,
                ContractId = d.ContractId,
                CounterpartyId = d.CounterpartyId,
                CounterpartyName = d.CounterpartyName,
                CropYear = d.CropYear,
                Garbage = d.Garbage,
                Id = d.Id,
                Infection = d.Infection,
                Price = d.Price,
                Process = d.Process,
                Product = d.Product,
                RecordDate = d.RecordDate,
                Wetness = d.Wetness
            });

            if (!string.IsNullOrEmpty(args.OrderBy))
            {
                switch (args.OrderBy)
                {
                    case "Amount":
                        {
                            if (args.Desc != null && args.Desc == true)
                            {
                                query = query.OrderByDescending(d => d.Amount);
                            }
                            else
                            {
                                query = query.OrderBy(d => d.Amount);
                            }
                            break;
                        }
                    case "BranchId":
                        {
                            if (args.Desc != null && args.Desc == true)
                            {
                                query = query.OrderByDescending(d => d.BranchId);
                            }
                            else
                            {
                                query = query.OrderBy(d => d.BranchId);
                            }
                            break;
                        }
                    case "ContractId":
                        {
                            if (args.Desc != null && args.Desc == true)
                            {
                                query = query.OrderByDescending(d => d.ContractId);
                            }
                            else
                            {
                                query = query.OrderBy(d => d.ContractId);
                            }
                            break;
                        }
                    case "CounterpartyId":
                        {
                            if (args.Desc != null && args.Desc == true)
                            {
                                query = query.OrderByDescending(d => d.CounterpartyId);
                            }
                            else
                            {
                                query = query.OrderBy(d => d.CounterpartyId);
                            }
                            break;
                        }
                    case "CounterpartyName":
                        {
                            if (args.Desc != null && args.Desc == true)
                            {
                                query = query.OrderByDescending(d => d.CounterpartyName);
                            }
                            else
                            {
                                query = query.OrderBy(d => d.CounterpartyName);
                            }
                            break;
                        }
                    case "CropYear":
                        {
                            if (args.Desc != null && args.Desc == true)
                            {
                                query = query.OrderByDescending(d => d.CropYear);
                            }
                            else
                            {
                                query = query.OrderBy(d => d.CropYear);
                            }
                            break;
                        }
                    case "Garbage":
                        {
                            if (args.Desc != null && args.Desc == true)
                            {
                                query = query.OrderByDescending(d => d.Garbage);
                            }
                            else
                            {
                                query = query.OrderBy(d => d.Garbage);
                            }
                            break;
                        }
                    case "Infection":
                        {
                            if (args.Desc != null && args.Desc == true)
                            {
                                query = query.OrderByDescending(d => d.Infection);
                            }
                            else
                            {
                                query = query.OrderBy(d => d.Infection);
                            }
                            break;
                        }
                    case "Price":
                        {
                            if (args.Desc != null && args.Desc == true)
                            {
                                query = query.OrderByDescending(d => d.Price);
                            }
                            else
                            {
                                query = query.OrderBy(d => d.Price);
                            }
                            break;
                        }
                    case "Product":
                        {
                            if (args.Desc != null && args.Desc == true)
                            {
                                query = query.OrderByDescending(d => d.Product);
                            }
                            else
                            {
                                query = query.OrderBy(d => d.Product);
                            }
                            break;
                        }
                    case "RecordDate":
                        {
                            if (args.Desc != null && args.Desc == true)
                            {
                                query = query.OrderByDescending(d => d.RecordDate);
                            }
                            else
                            {
                                query = query.OrderBy(d => d.RecordDate);
                            }
                            break;
                        }
                    case "Wetness":
                        {
                            if (args.Desc != null && args.Desc == true)
                            {
                                query = query.OrderByDescending(d => d.Wetness);
                            }
                            else
                            {
                                query = query.OrderBy(d => d.Wetness);
                            }
                            break;
                        }
                    default:
                        {
                            if (args.Desc != null && args.Desc == true)
                            {
                                query = query.OrderByDescending(d => d.Id);
                            }
                            else
                            {
                                query = query.OrderBy(d => d.Id);
                            }
                            break;
                        }
                }

            }
            if (args.PageCount != null && args.PageCount > 0 && args.PageSize != null && args.PageSize != 0)
            {
                query = query.Skip((args.PageCount.Value - 1) * args.PageSize.Value).Take(args.PageSize.Value);
            }

            data = query.ToList();
            if (data == null)
            {
                data = new List<GrainInput>();
            }
            return data;
        }
        public static int GetDataCount()
        {
            int count = 0;
            GrainTwContext db = new GrainTwContext();
            try
            {
                count = db.TblGrainReceipts.Count();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return count;
        }

        public static void DeleteGrainData(DeleteGrainDataArgs args)
        {
            GrainTwContext db = new GrainTwContext();
            if (args != null && args.RowsIds != null)
            {
                foreach (var a in args.RowsIds)
                {
                    var ch = db.TblGrainReceipts.FirstOrDefault(d => d.Id == a);
                    if (ch != null)
                    {
                        db.TblGrainReceipts.RemoveRange(db.TblGrainReceipts.Where(d => d.Id == a));
                    }
                }
            }


            db.SaveChanges();
        }

        public static List<GrainInput> GetDataGroups(GrainOrderByArgs args)
        {
            List<GrainInput> dataGroups = new List<GrainInput>();
            GrainTwContext db = new GrainTwContext();
            IOrderedQueryable<TblGrainReceipt> orderQuery;
            IQueryable<TblGrainReceipt> query = db.TblGrainReceipts;

            orderQuery = query.OrderBy(d => 1);
            if (args.OrderBy != null && args.OrderBy.Count() > 0)
            {
                foreach (var a in args.OrderBy)
                {
                    switch (a)
                    {
                        case "Amount":
                            {
                                orderQuery = orderQuery.ThenBy(d => d.Process);
                                break;
                            }
                        case "BranchId":
                            {
                                orderQuery = orderQuery.ThenBy(d => d.BranchId);
                                break;
                            }
                        case "ContractId":
                            {
                                orderQuery = orderQuery.ThenBy(d => d.ContractId);
                                break;
                            }
                        case "RecordDate":
                            {
                                orderQuery = orderQuery.ThenBy(d => d.RecordDate);
                                break;
                            }
                        case "CounterpartyId":
                            {
                                orderQuery = orderQuery.ThenBy(d => d.CounterpartyId);
                                break;
                            }
                        case "CounterpartyName":
                            {
                                orderQuery = orderQuery.ThenBy(d => d.CounterpartyName);
                                break;
                            }
                        case "CropYear":
                            {
                                orderQuery = orderQuery.ThenBy(d => d.CropYear);
                                break;
                            }
                        case "Garbage":
                            {
                                orderQuery = orderQuery.ThenBy(d => d.Garbage);
                                break;
                            }
                        case "Id":
                            {
                                orderQuery = orderQuery.ThenBy(d => d.Id);
                                break;
                            }
                        case "Infection":
                            {
                                orderQuery = orderQuery.ThenBy(d => d.Infection);
                                break;
                            }
                        case "Price":
                            {
                                orderQuery = orderQuery.ThenBy(d => d.Price);
                                break;
                            }
                        case "Process":
                            {
                                orderQuery = orderQuery.ThenBy(d => d.Process);
                                break;
                            }
                        case "Product":
                            {
                                orderQuery = orderQuery.ThenBy(d => d.Product);
                                break;
                            }
                        case "Wetness":
                            {
                                orderQuery = orderQuery.ThenBy(d => d.Wetness);
                                break;
                            }
                        default:
                            {
                                orderQuery = orderQuery.ThenBy(d => d.Id);
                                break;
                            }

                    }
                }
            }
            if (args.PageCount != null && args.PageCount > 0 && args.PageSize != null && args.PageSize != 0)
            {
                query = orderQuery.Skip((args.PageCount.Value - 1) * args.PageSize.Value).Take(args.PageSize.Value);
            }
            else
            {
                query = orderQuery;
            }
            try
            {
                dataGroups = query.Select(d => new GrainInput
                {
                    Id = d.Id,
                    Amount = d.Amount,
                    RecordDate = d.RecordDate,
                    BranchId = d.BranchId,
                    ContractId = d.ContractId,
                    CounterpartyId = d.CounterpartyId,
                    CounterpartyName = d.CounterpartyName,
                    CropYear = d.CropYear,
                    Garbage = d.Garbage,
                    Infection = d.Infection,
                    Price = d.Price,
                    Process = d.Process,
                    Product = d.Product,
                    Wetness = d.Wetness
                }).ToList(); ;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dataGroups;
        }

        public static List<TblGrainReceiptMerged> MergeDataGroups(GrainOrderByArgs args)
        {
            List<TblGrainReceiptMerged> MergedGrainData = new List<TblGrainReceiptMerged>();
            GrainTwContext db = new GrainTwContext();
            var groups = db.TblGrainReceipts.AsEnumerable().GroupBy(x => x, new ItemEqualityComparer(args.OrderBy.ToArray())).ToList();
            var t = typeof(TblGrainReceipt);
            var tg = typeof(TblGrainReceiptMerged);
            var groupProperties = t.GetProperties();
            var allPropertiesMerged = tg.GetProperties();
            int groupCount = groups.Count();

            if (args.OrderBy?.Any() is not true)
                return new List<TblGrainReceiptMerged>();
            db.TblGrainReceiptMerged.RemoveRange(db.TblGrainReceiptMerged.ToList());
            for (int i = 0; i < groupCount; i++)
            {
                TblGrainReceiptMerged grainInput = new();
                List<TblGrainReceipt> group = groups[i].ToList();
                int cgc = group.Count();
                foreach (var a in groupProperties)
                {
                    if (args.OrderBy.Contains(a.Name))
                    {
                        allPropertiesMerged.FirstOrDefault(d => d.Name == a.Name)?.SetValue(grainInput, a.GetValue(group.FirstOrDefault()).ToString());
                    }
                    else if (a.Name == "Price")
                    {
                        double sumAll = 0;
                        sumAll = Convert.ToDouble(group.Sum(d => Convert.ToDouble(a.GetValue(d))));
                        allPropertiesMerged.FirstOrDefault(d => d.Name == a.Name)?.SetValue(grainInput, (sumAll / cgc).ToString("0.00"));
                    }
                    else if (a.Name == "Amount")
                    {
                        int sumAll = 0;
                        sumAll = Convert.ToInt32(group.Sum(d => Convert.ToInt32(a.GetValue(d))));
                        allPropertiesMerged.FirstOrDefault(d => d.Name == a.Name)?.SetValue(grainInput, sumAll.ToString());
                    }
                    else if (a.Name == "Wetness")
                    {
                        double sumAll = 0;
                        sumAll = Convert.ToDouble(group.Sum(d => Convert.ToDouble(a.GetValue(d))));
                        allPropertiesMerged.FirstOrDefault(d => d.Name == a.Name)?.SetValue(grainInput, (sumAll / cgc).ToString("0.00"));
                    }
                    else if (a.Name == "Garbage")
                    {
                        string str = string.Empty;
                        double sumAll = 0;
                        sumAll = Convert.ToDouble(group.Sum(d => Convert.ToDouble(a.GetValue(d)?.ToString()?.Replace(".", ","))));
                        str = (sumAll / cgc).ToString("0.00");
                        allPropertiesMerged.FirstOrDefault(d => d.Name == a.Name)?.SetValue(grainInput, str);
                    }
                    else if (a.Name == "Infection")
                    {
                        string str = string.Empty;
                        double sumAll = 0;
                        var sum = group.Select(d => a.GetValue(d)?.ToString()?.Replace(" ст", "").Replace("н-обн.", "").Replace(".", ","));
                        sumAll = Convert.ToDouble(sum.Sum(d => string.IsNullOrEmpty(d) ? 0 : Convert.ToDouble(d)));
                        str = (sumAll / cgc).ToString("0.00");
                        allPropertiesMerged.FirstOrDefault(d => d.Name == a.Name)?.SetValue(grainInput, str);
                    }
                    else if ((a.PropertyType == typeof(string) || a.Name.Contains("Id")) && a.Name != "SysId")
                    {
                        var values = group
                            .Select(g => a.GetValue(g)?.ToString())
                            .Distinct();
                        var str = string.Join("; ", values);
                        allPropertiesMerged.FirstOrDefault(d => d.Name == a.Name)?.SetValue(grainInput, str);
                    }
                    else if (a.PropertyType == typeof(DateTime))
                    {
                        string str = string.Empty;
                        var minDate = group.Min(d => a.GetValue(d))?.ToString();
                        var maxDate = group.Max(d => a.GetValue(d))?.ToString();
                        str = minDate + " - " + maxDate;
                        allPropertiesMerged.FirstOrDefault(d => d.Name == a.Name)?.SetValue(grainInput, str);
                    }
                }

                MergedGrainData.Add(grainInput);

                db.TblGrainReceiptMerged.Add(grainInput);
                db.SaveChanges();
            }
            if (args.PageCount != null && args.PageCount > 0 && args.PageSize != null && args.PageSize != 0)
            {
                MergedGrainData = MergedGrainData.Skip((args.PageCount.Value - 1) * args.PageSize.Value).Take(args.PageSize.Value).ToList();
            }

            return MergedGrainData;
        }
        public static int MergeDataGroupsCount()
        {
            int? count = 0;
            GrainTwContext db = new GrainTwContext();
            count = db.TblGrainReceiptMerged.Count();
            if (count == null)
            {
                count = 0;
            }
            return count.Value;
        }

        public static void SaveGrainInfo(GrainInput grain)
        {
            if (grain == null)
            {
                return;
            }
            GrainTwContext db = new GrainTwContext();
            try
            {
                int idCr = 0;
                try
                {
                    idCr = db.TblGrainReceipts.Max(d => d.Id);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                if(idCr == 0)
                {
                    idCr = 1;
                }
                else
                {
                    idCr = idCr + 1;
                }
                db.TblGrainReceipts.Add(new TblGrainReceipt
                {
                    Amount = grain.Amount,
                    BranchId = grain.BranchId,
                    ContractId = grain.ContractId,
                    CounterpartyId = grain.CounterpartyId,
                    CounterpartyName = grain.CounterpartyName,
                    CropYear = grain.CropYear,
                    Garbage = grain.Garbage,
                    Id = idCr,
                    Infection = grain.Infection,
                    Price = grain.Price,
                    Process = grain.Process,
                    Product = grain.Product,
                    RecordDate = grain.RecordDate,
                    Wetness = grain.Wetness,
                });
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void EditGrainInfo(GrainInput grain)
        {
            if (grain == null)
            {
                return;
            }
            GrainTwContext db = new GrainTwContext();
            try
            {
                db.TblGrainReceipts.RemoveRange(db.TblGrainReceipts.Where(d => d.Id == grain.Id).ToList());
                db.TblGrainReceipts.Add(new TblGrainReceipt
                {
                    Amount = grain.Amount,
                    BranchId = grain.BranchId,
                    ContractId = grain.ContractId,
                    CounterpartyId = grain.CounterpartyId,
                    CounterpartyName = grain.CounterpartyName,
                    CropYear = grain.CropYear,
                    Garbage = grain.Garbage,
                    Id = grain.Id,
                    Infection = grain.Infection,
                    Price = grain.Price,
                    Process = grain.Process,
                    Product = grain.Product,
                    RecordDate = grain.RecordDate,
                    Wetness = grain.Wetness,
                });
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    public class DeleteGrainDataArgs
    {
        public List<int>? RowsIds { get; set; }
    }

    public class ItemEqualityComparer : IEqualityComparer<TblGrainReceipt>
    {
        private string[] _fields;

        public ItemEqualityComparer(params string[] fields)
        {
            _fields = fields;
        }

        public bool Equals(TblGrainReceipt a, TblGrainReceipt b)
        {
            foreach (string f in _fields)
            {
                switch (f)
                {
                    case nameof(TblGrainReceipt.Id) when a.Id != b.Id: return false;
                    case nameof(TblGrainReceipt.Infection) when a.Infection != b.Infection: return false;
                    case nameof(TblGrainReceipt.ContractId) when a.ContractId != b.ContractId: return false;
                    case nameof(TblGrainReceipt.Product) when a.Product != b.Product: return false;
                    case nameof(TblGrainReceipt.Process) when a.Process != b.Process: return false;
                    case nameof(TblGrainReceipt.Amount) when a.Amount != b.Amount: return false;
                    case nameof(TblGrainReceipt.BranchId) when a.BranchId != b.BranchId: return false;
                    case nameof(TblGrainReceipt.CounterpartyId) when a.CounterpartyId != b.CounterpartyId: return false;
                    case nameof(TblGrainReceipt.CounterpartyName) when a.CounterpartyName != b.CounterpartyName: return false;
                    case nameof(TblGrainReceipt.CropYear) when a.CropYear != b.CropYear: return false;
                    case nameof(TblGrainReceipt.Garbage) when a.Garbage != b.Garbage: return false;
                    case nameof(TblGrainReceipt.RecordDate) when a.RecordDate != b.RecordDate: return false;
                    case nameof(TblGrainReceipt.Wetness) when a.Wetness != b.Wetness: return false;
                }
            }

            return true;
        }

        public int GetHashCode(TblGrainReceipt item)
        {
            int hash = 0;

            foreach (string f in _fields)
            {
                switch (f)
                {
                    case nameof(TblGrainReceipt.Id): hash = HashCode.Combine(hash, item.Id); break;
                    case nameof(TblGrainReceipt.ContractId): hash = HashCode.Combine(hash, item.ContractId); break;
                    case nameof(TblGrainReceipt.Product): hash = HashCode.Combine(hash, item.Product); break;
                    case nameof(TblGrainReceipt.Infection): hash = HashCode.Combine(hash, item.Infection); break;
                    case nameof(TblGrainReceipt.Amount): hash = HashCode.Combine(hash, item.Amount); break;
                    case nameof(TblGrainReceipt.BranchId): hash = HashCode.Combine(hash, item.BranchId); break;
                    case nameof(TblGrainReceipt.CounterpartyId): hash = HashCode.Combine(hash, item.CounterpartyId); break;
                    case nameof(TblGrainReceipt.CounterpartyName): hash = HashCode.Combine(hash, item.CounterpartyName); break;
                    case nameof(TblGrainReceipt.CropYear): hash = HashCode.Combine(hash, item.CropYear); break;
                    case nameof(TblGrainReceipt.Garbage): hash = HashCode.Combine(hash, item.Garbage); break;
                    case nameof(TblGrainReceipt.Price): hash = HashCode.Combine(hash, item.Price); break;
                    case nameof(TblGrainReceipt.Process): hash = HashCode.Combine(hash, item.Process); break;
                    case nameof(TblGrainReceipt.RecordDate): hash = HashCode.Combine(hash, item.RecordDate); break;
                    case nameof(TblGrainReceipt.Wetness): hash = HashCode.Combine(hash, item.Wetness); break;
                }
            }

            return hash;
        }
    }
}
