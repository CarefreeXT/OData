using System;
using Caredev.OData.Core.UriParser;
using Irony.Parsing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Caredev.OData.Tests
{
    [TestClass]
    public class ODataGrammarTest
    {
        [TestMethod]
        public void ComplexTest() => ParseTest(
            @"SEOrders?$filter=contains(BillNo,'df')&
                       $expand=CompanyBranch,BillTypeSub,SEOrderDetls,BillStatus,CompanyCustomer&
                       $select=Namespace.PreferredSupplier/AccountRepresentative,Address/Street,Address/Namespace.AddressWithLocation/Location&
                       $orderby=BillID desc&
                       $top=60&
                       $count=true&
                       $skip=0&
                       @AAA=12");
        [TestMethod]
        public void EntityTest() => ParseTest(
            @"Products",
            @"ProductsByCategoryId(categoryId=2)",
            @"ProductsByColor(color=@color)?@color='red'",
            @"BestProductEverCreated",
            @"Categories(1)",
            @"Products/Model.MostExpensive()",
            @"Products(1)/Supplier",
            @"Products(1)/Model.MostRecentOrder()",
            @"Categories(1)/Products",
            @"Categories(1)/Model.TopTenProducts()",
            @"Categories(1)/Products/Model.AllOrders()");
        [TestMethod]
        public void RelatedEntitiesConstraintsTest() => ParseTest(
            @"Orders(1)/Items(OrderID=1,ItemNo=2)",
            @"Orders(1)/Items(2)");
        [TestMethod]
        public void ReferencesEntitiesTest() => ParseTest(
            @"Categories(1)/Products/$ref",
            @"Categories(1)/Products/$ref?$id=Products(0)",
            @"Products(0)/Category/$ref");
        [TestMethod]
        public void CollectionCount() => ParseTest(
            @"Categories(1)/Products/$count",
            @"Products/$count",
            @"Categories?$filter=Products/$count gt 0",
            @"Categories?$orderby=Products/$count");
        [TestMethod]
        public void CrossJoinTest() => ParseTest(@"$crossjoin(Products,Sales)?$filter=Products/ID eq Sales/ProductID");
        [TestMethod]
        public void AllEntitiesTest() => ParseTest("$all");

        [TestMethod]
        public void LogicalOperatorTest() => ParseTest(
            @"Products?$filter=Name eq 'Milk'",
            @"Products?$filter=Name ne 'Milk'",
            @"Products?$filter=Name gt 'Milk'",
            @"Products?$filter=Name ge 'Milk'",
            @"Products?$filter=Name lt 'Milk'",
            @"Products?$filter=Name le 'Milk'",
            @"Products?$filter=Name eq 'Milk' and Price lt '2.55'",
            @"Products?$filter=Name eq 'Milk' or Price lt 2.55",
            @"Products?$filter=not endswith(Name,'ilk')");
        [TestMethod]
        public void ArithmeticOperatorTest() => ParseTest(
            @"Products?$filter=Price add 2.45 eq 5.00",
            @"Products?$filter=Price sub 0.55 eq 2.00",
            @"Products?$filter=Price mul 2.0 eq 5.10",
            @"Products?$filter=Price div 2.55 eq 1",
            @"Products?$filter=Rating mod 5 eq 0");
        [TestMethod]
        public void GroupingTest() => ParseTest(@"Products?$filter=(4 add 5) mod (4 sub 1) eq 0");
        [TestMethod]
        public void CanonicalFunctionsTest() => ParseTest(
            @"Customers?$filter=contains(CompanyName,'Alfreds')",
            @"Customers?$filter=endswith(CompanyName,'Futterkiste')",
            @"Customers?$filter=startswith(CompanyName,'Alfr')",
            @"Customers?$filter=length(CompanyName) eq 19",
            @"Customers?$filter=indexof(CompanyName,'lfreds') eq 1",
            @"Customers?$filter=substring(CompanyName, 1) eq 'lfreds Futterkiste'",
            @"Customers?$filter=substring(CompanyName,1,2) eq 'lf'",
            @"Customers?$filter=tolower(CompanyName) eq 'alfreds futterkiste'",
            @"Customers?$filter=toupper(CompanyName) eq 'ALFREDS FUTTERKISTE'",
            @"Customers?$filter=concat(concat(City,', '), Country) eq 'Berlin, Germany'",
            @"Employees?$filter=year(BirthDate) eq 1971",
            @"Employees?$filter=month(BirthDate) eq 5",
            @"Employees?$filter=day(BirthDate) eq 8",
            @"Employees?$filter=hour(BirthDate) eq 4",
            @"Employees?$filter=minute(BirthDate) eq 40",
            @"Employees?$filter=second(BirthDate) eq 40",
            @"Employees?$filter=fractionalseconds(BirthDate) lt 0.1",
            //@"date(Edm.DateTimeOffset)",
            //@"time(Edm.DateTimeOffset)",
            //@"totaloffsetminutes(Edm.DateTimeOffset)",
            //@"now()",
            //@"maxdatetime()",
            //@"mindatetime()",
            //@"totalseconds(Edm.Duration)",
            @"Orders?$filter=round(Freight) eq 32",
            @"Orders?$filter=floor(Freight) eq 32",
            @"Orders?$filter=ceiling(Freight) eq 32",
            @"Orders?$filter=isof(Customer,NorthwindModel.VIPCustomer)"
            //@"cast(expression,type)",
            //@"geo.distance(Edm.GeographyPoint,Edm.GeographyPoint)",
            //@"geo.distance(Edm.GeometryPoint,Edm.GeometryPoint)",
            //@"geo.intersects(Edm.GeographyPoint,Edm.GeographyPolygon)",
            //@"geo.intersects(Edm.GeometryPoint,Edm.GeometryPolygon)",
            //@"geo.length(Edm.GeographyLineString)"
            );
        [TestMethod]
        public void LambdaOperatorsTest() => ParseTest(
            @"Orders?$filter=Items/all(d:d/Quantity gt 100)",
            @"Orders?$filter=Items/any(d:d/Quantity gt 100)");
        [TestMethod]
        public void PrimitiveLiteralsTest() => ParseTest(
            @"Products?$filter=ReleaseDate gt date'2013-05-24'");
        [TestMethod]
        public void ItTest() => ParseTest(
            @"Customers(1)/EmailAddresses?$filter=endswith($it,'.com')",
            @"Customers?$expand=Orders($filter=$it/Address/City eq ShipTo/City)");
        [TestMethod]
        public void RootTest() => ParseTest(
            @"Employees?$filter=LastName eq $root/Employees('A1245')/LastName",
            @"ProductsOrderedBy(Customers=@c)?@c=[$root/Customers('ALFKI'),$root/Customers('BLAUS')]");
        [TestMethod]
        public void SystemQueryOptionExpandTest() => ParseTest(
            @"Products?$expand=Category",
            @"Customers?$expand=Addresses/Country",
            @"Categories?$expand=Products($filter=DiscontinuedDate eq null)",
            @"Categories?$expand=Products/$ref",
            @"Categories?$expand=Products/Sales.PremierProduct/$ref",
            @"Categories?$expand=Products/Sales.PremierProduct/$ref($filter=CurrentPromotion eq null)",
            @"Employees?$expand=Model.Manager/DirectReports($levels=3)",
            @"Categories?$expand=*/$ref,Supplier",
            @"Categories?$expand=*($levels=2)");
        [TestMethod]
        public void SystemQueryOptionSelctTest() => ParseTest(
            @"Products?$select=*",
            @"Products?$select=Rating,ReleaseDate",
            @"Products?$select=Name,Description&$expand=Category($select=Name)",
            @"Suppliers?$select=Namespace.PreferredSupplier/AccountRepresentative,
                                Address/Street,
                                Address/Namespace.AddressWithLocation/Location",
            @"Products?$select=ID,Model.ActionName,Model2.*");
        [TestMethod]
        public void SystemQueryOptionOtherTest() => ParseTest(
            @"Orders?$skip=0",
            @"Orders?$top=60",
            @"Orders?$orderby=BillID desc",
            @"Products?$search=blue OR green",
            @"Orders?$count=true");
        [TestMethod]
        public void CustomQueryOptionsTest() => ParseTest("Products?debug-mode=true");
        [TestMethod]
        public void ParameterAliasesTest() => ParseTest(
            @"Movies?$filter=contains(@word,Title)&@word='Black'",
            @"Movies?$filter=Title eq @title&@title='Wizard of Oz'",
            @"Products/Model.WithIngredients(Ingredients=@i)?@i=[""Carrots"", ""Ginger"", ""Oranges""]");
        
        [TestMethod]
        public void DataAggregation_3Test() => ParseTest(
            //Example5
            @"Sales?$apply=aggregate(Amount with sum as Total,Amount with max as MxA)",
            //Example6
            @"Sales?$apply=aggregate(Amount mul Product/TaxRate with sum as Tax)",
            //Example7
            @"Products?$apply=aggregate(Sales(Amount mul Product/TaxRate with sum as Tax))",
            //Example8
            @"Sales?$apply=aggregate(Amount with sum as Total)",
            //Example9
            @"Sales?$apply=aggregate(Amount with min as MinAmount)",
            //Example10
            @"Sales?$apply=aggregate(Amount with max as MaxAmount)",
            //Example11
            @"Sales?$apply=aggregate(Amount with average as AverageAmount)",
            //Example12
            @"Sales?$apply=aggregate(Product with countdistinct as DistinctProducts)",
            //Example13
            @"Sales?$apply=groupby((Customer/Country),
                   aggregate(Amount with sum as Total,
                             Product/Name with Custom.concat as ProductNames))",
            //Example14
            @"Sales?$apply=aggregate(Amount with sum as DailyAverage 
                               from Time with average)",
            @"Sales?$apply=groupby((Time),aggregate(Amount with sum as Total)) 
                  /aggregate(Total with average as DailyAverage)",
            //Example15
            @"Sales?$apply=aggregate($count as SalesCount)",
            //Example16
            @"Sales?$apply=topcount(2,Amount)",
            //Example17
            @"Sales?$apply=topsum(15,Amount)",
            //Example18
            @"Sales?$apply=toppercent(50,Amount)",
            //Example19
            @"Sales?$apply=bottomcount(2,Amount)",
            //Example20
            @"Sales?$apply=bottomsum(7,Amount)",
            //Example21
            @"Sales?$apply=bottompercent(50,Amount)",
            //Example22
            @"Sales?$apply=identity",
            //Example23
            @"Sales?$apply=concat(topcount(2,Amount),
                          aggregate(Amount))",
            //Example24
            @"Sales?$apply=groupby((Customer/Country,Product/Name),
                           aggregate(Amount with sum as Total))",
            //Example25
            @"Sales?$apply=groupby((Product/Name,Amount))",
            @"Sales?$expand=Product($select=Name)&$select=Amount",
            //Example27
            @"Sales?$apply=groupby((rollup(Customer/Country,Customer/Name),
                            rollup(Product/Category/Name,Product/Name),
                            Currency/Code),
                           aggregate(Amount with sum as Total))",
            //Example28
            @"Sales?$apply=filter(Amount gt 3)",
            //Example29
            @"Customers?$apply=expand(Sales,filter(Amount gt 3))",
            @"Customers?$expand=Sales($filter=Amount gt 3)",
            //Example30
            @"Categories?$apply=expand(Products,expand(Sales,filter(Amount gt 3)))",
            //Example31
            @"Sales?$apply=search(coffee)",
            //Example32
            @"Sales?$apply=compute(Amount mul Product/TaxRate as Tax)",
            //Example33
            @"Sales?$apply=aggregate(Amount with sum as Total)
                    &$filter=isdefined(Product)",
            //Example34
            @"Products?$expand=Sales($apply=aggregate(Amount with sum as Total))");

        [TestMethod]
        public void DataAggregation_4Test() => ParseTest(
            //Example35
            @"Sales?$apply=groupby((Customer/Country,Product/Name),
                            aggregate(Amount with sum as Total))");

        [TestMethod]
        public void DataAggregation_5Test() => ParseTest(
            //Example36
            @"$crossjoin(Products,Sales)
                         ?$expand=Products($select=Name),Sales($select=Amount)
                         &$filter=Products/ID eq Sales/ProductID",
            //Example37
            @"$crossjoin(Products,Sales)
                         ?$apply=filter(Products/ID eq Sales/ProductID)
                         /groupby((Products/Name),
                                   aggregate(Sales(Amount with sum as Total)))");

        [TestMethod]
        public void DataAggregation_6_2Test() => ParseTest(
            //Example39
            @"Sales?$apply=groupby((Time/Month),aggregate(Forecast))",
            @"$crossjoin(Time)?$apply=groupby((Time/Year),aggregate(Budget))");

        [TestMethod]
        public void DataAggregation_6_3Test() => ParseTest(
            //Example42
            @"SalesOrganizations?$filter=$it/Aggregation.isdescendant(Hierarchy='SalesOrgHierarchy',Node='EMEA')",
            //Example43
            @"SalesOrganizations?$filter=
                   $it/Aggregation.isdescendant(Hierarchy='SalesOrgHierarchy',
                                                Node='EMEA',MaxDistance=1)",
            //Example44
            @"SalesOrganizations?$filter=
                         $it/Aggregation.isleaf(Hierarchy='SalesOrgHierarchy')",
            //Example45
            @"SalesOrganizations?$filter=
                         $it/Aggregation.isleaf(Hierarchy='SalesOrgHierarchy')
                      &$expand=Superordinate($select=ID)",
            //Example46
            @"Sales?$select=ID&$filter=
     SalesOrganization/Aggregation.isdescendant(Hierarchy='SalesOrgHierarchy',
                                                Node='EMEA')");
        
        [TestMethod]
        public void DataAggregation_7_1Test() => ParseTest(
            //Example49
            @"Customers?$apply=groupby((Name))",
            //Example50
            @"Sales?$apply=groupby((Customer/Name))",
            @"Sales?$expand=Customer($select=Name) ",
            //Example51
            @"Sales?$apply=groupby((Customer/Name,Customer/ID))",
            @"Sales?$apply=groupby((Customer))
                    &$expand=Customer($select=Name,ID)",
            //Example52
            @"Sales?$apply=groupby((Customer/Name,Customer/ID,Product/Name))");

        [TestMethod]
        public void DataAggregation_7_2Test() => ParseTest(
            //Example53
            @"Products?$apply=groupby((Name),
                              aggregate(Sales/Amount with sum as Total))",
            //Example54
            @"Products?$apply=groupby((Name,Sales/Currency/Code),
                              aggregate(Sales/Amount with sum as Total))",
            //Example55
            @"Customers?$apply=groupby((Country,Sales/Product/Name))",
            //Example56
            @"Sales?$apply=groupby((Customer/Country),
                            aggregate(Amount with average as AverageAmount))",
            //Example57
            @"Products?$apply=groupby((Name),aggregate(Sales/$count as SalesCount))",
            //Example58
            @"Products?$apply=groupby((Name),aggregate(Sales/$count as SalesCount,
                                     Sales(Amount with sum as TotalAmount)))",
            //Example59
            @"Products?$apply=groupby((Name),aggregate(Sales($count as SalesCount),
                                     Sales(Amount with sum as TotalAmount)))");

        [TestMethod]
        public void DataAggregation_7_3Test() => ParseTest(
            //Example60
            @"Sales?$apply=groupby((Customer/Country),
                           aggregate(Amount with sum as Actual,Forecast))",
            //Example61
            @"Products?$apply=groupby((Name),
                              aggregate(Sales(Amount with sum as Actual), 
                                        Sales/Forecast))",
            //Example62
            @"Sales?$apply=groupby((Customer/Country),aggregate(Amount))");

        [TestMethod]
        public void DataAggregation_7_4Test() => ParseTest(
            //Example 63
            @"Sales?$apply=groupby((Customer/Country),
                           aggregate(Amount with sum as Total,
                                     Amount with average as AvgAmt))",
            //Example 64
            @"Products?$apply=groupby((Name),
                              aggregate(Sales(Amount with sum as Total), 
                                        Sales(Amount with average as AvgAmt)))",
            //Example 65
            @"Sales?$apply=groupby((Amount),aggregate(Amount with sum as Total))");

        [TestMethod]
        public void DataAggregation_7_5Test() => ParseTest(
            //Example 66
            @"Sales?$apply=concat(
                     groupby((Customer/Country,Product/Name,Currency/Code),
                             aggregate(Amount with sum as Total))
                       /groupby((Customer/Country,Currency/Code),
                                topcount(1,Total)),
                     groupby((Customer/Country,Currency/Code),
                             aggregate(Amount with sum as Total)))",
            //Example 67
            @"Sales?$apply=groupby((Customer/Country,Product/Name,Currency/Code),
                      topcount(2,Amount)/aggregate(Amount with sum as Total))");

        [TestMethod]
        public void DataAggregation_7_6Test() => ParseTest(
            //Example 68
            @"Sales?$apply=groupby((Customer/Country,Product/Name),
                         aggregate(Amount with sum as Total))
                  /groupby((Customer/Country),
                           Self.TopCountAndBalance(Count=1,Property='Total'))");

        [TestMethod]
        public void DataAggregation_7_7Test() => ParseTest(
            //Example 69
            @"Sales?$apply=groupby((Product/ID,Product/Name,Time/Month),
                           aggregate(Amount with sum as Total))
                  /groupby((Product/ID,Product/Name),
                           aggregate(Total with average as AverageAmount))",
            @"Sales?$apply=groupby((Product/ID,Product/Name),
                      aggregate(Amount with sum as MonthlyAverage
                                       from Time/Month with average))",
            //Example 70
            @"Sales?$apply=groupby((rollup($all,Customer/Country,Customer/ID),
                            Currency/Code),
                           aggregate(Amount with sum as CustomerCountryAverage
                                     from Customer/ID      with average
                                     from Customer/Country with average))");

        [TestMethod]
        public void DataAggregation_7_8Test() => ParseTest(
            @"Sales?$apply=aggregate(Amount with sum as Total,Amount with max as MxA)",
            //Example 71
            @"Sales?$apply=filter(Amount le 1)/aggregate(Amount with sum as Total)",
            //Example 72
            @"Sales?$apply=filter(Amount le 2)/groupby((Product/Name),
                                         aggregate(Amount with sum as Total))
                            &$filter=Total ge 4",
            //Example 73
            @"Sales?$apply=aggregate(Amount as DailyAverage from Time with average)",
            @"Sales?$apply=groupby((Time),aggregate(Amount with sum as Total))
                  /aggregate(Total with average as DailyAverage)",
            //Example 74
            @"Cities?$apply=groupby((Continent/Name,Country/Name),
                            aggregate(Population with sum as TotalPopulation))",
            //Example 75
            @"Cities?$apply=filter(Population ge 10000000)
                   /groupby((Continent/Name,Country/Name),
                            aggregate(Population with sum as TotalPopulation))",
            //Example 76
            @"Cities?$apply=groupby((Continent/Name,Country/Name),
                          aggregate(Population with sum as CountryPopulation))
                   /filter(CountryPopulation ge 10000000)
                   /concat(identity,
                         groupby((Continent/Name),
                           aggregate(CountryPopulation with sum 
                                      as TotalPopulation)))",
            @"Cities?$apply=groupby((Continent/Name,Country/Name),
                          aggregate(Population with sum as CountryPopulation))
                   /filter(CountryPopulation ge 10000000)
                   /groupby((rollup(Continent/Name,Country/Name)),
                             aggregate(CountryPopulation with sum 
                                       as TotalPopulation))",
            //Example 77
            @"Cities?$apply=groupby((Continent/Name,Country/Name),
                          aggregate(Population with sum as CountryPopulation))
                   /concat(filter(CountryPopulation ge 10000000),
                         groupby((Continent/Name),
                                 aggregate(CountryPopulation with sum 
                                       as TotalPopulation)))",
            //Example 78
            @"SalesOrders?$apply=filter(Status eq 'incomplete')
                        /expand(Items,filter(not Shipped))
                        /groupby((Customer/Country),
                         aggregate(Items/Amount with sum as ItemAmount))"
            );

        private readonly static ODataGrammar Grammar = new ODataGrammar();
        private void ParseTest(params string[] infos)
        {
            var parser = new Parser(Grammar);
            for (int i = 0; i < infos.Length; i++)
            {
                var result = parser.Parse(infos[i]);
                Assert.IsNotNull(result.Root, $"Item {i} error.");
            }
        }
    }
}
