// Copyright (c) CarefreeXT and Caredev Studios. All rights reserved.
// Licensed under the GNU Lesser General Public License v3.0.
// See LICENSE in the project root for license information.
namespace Caredev.OData.Core.UriParser
{
    using Irony.Parsing;
    [Language("OData", "4.0", "OData v4.0 grammar.")]
    internal class ODataGrammar : Grammar
    {
        public ODataGrammar()
        {
            #region ===== Operator And Punctuation =====
            var DOT = ToTerm(".", "dot");
            var AT = ToTerm("@", "at");
            var COLON = ToTerm(":", "colon");
            var COMMA = ToTerm(",", "comma");
            var EQ = ToTerm("=", "equal");
            var SIGN = ToTerm("+") | "-";
            var SEMI = ToTerm(";", "semi");
            var STAR = ToTerm("*", "star");
            var SQUOTE = ToTerm("'", "squote");
            var OPEN = ToTerm("(", "Lpar");
            var CLOSE = ToTerm(")", "Rpar");
            var SLASH = ToTerm("/", "slash");
            var AND = ToTerm("&", "and");
            var OR = ToTerm("|", "or");
            var DQUOTE = ToTerm("\"", "dquote");
            var QUESTION = ToTerm("?", "question");

            RegisterOperators(1, "or");
            RegisterOperators(2, "and");
            RegisterOperators(6, "eq", "ne");
            RegisterOperators(7, "gt", "lt", "le", "ge", "has");
            RegisterOperators(9, "add", "sub");
            RegisterOperators(10, "mul", "div", "mod");

            MarkPunctuation(",", "(", ")", "{", "}", "[", "]", ":");
            #endregion

            #region 1. Resource Path Terminal
            var odataRelativeUri = new NonTerminal("odataRelativeUri");

            var keyPredicate = new NonTerminal("keyPredicate");
            var keyValuePair = new NonTerminal("keyValuePair");
            var keyValuePairs = new NonTerminal("keyValuePairs");

            var count = new NonTerminal("count");
            var value = new NonTerminal("value");
            var @ref = new NonTerminal("ref");

            var resourcePath = new NonTerminal("resourcePath");
            var boundOperation = new NonTerminal("boundOperation");
            //propertyPath boundOperation singleNavigation
            var boundOperation_PropertyPath = new NonTerminal("boundOperation");
            //collectionPath singlePath complexPath
            var objectPath = new NonTerminal("objectPath");

            var functionParameters = new NonTerminal("functionParameters");
            var functionParameter = new NonTerminal("functionParameter");
            var parameterAlias = new NonTerminal("parameterAlias");
            var functionParameterList = new NonTerminal("functionParameter");

            var crossjoin = new NonTerminal("crossjoin");
            var crossjoinList = new NonTerminal("crossjoinList");
            #endregion
            #region 2. Query Options  Termianl
            var entityOption = new NonTerminal("entityOption");
            var entityOptions = new NonTerminal("entityOptions");
            var id = new NonTerminal("id");
            var searchOrExpr = new NonTerminal("searchOrExpr");
            var searchPhrase = new NonTerminal("searchPhrase");
            var searchWord = new NonTerminal("searchWord");
            var selectItem = new NonTerminal("selectItem");
            var systemQueryOption = new NonTerminal("systemQueryOption");
            var aliasAndValue = new NonTerminal("aliasAndValue");
            var customQueryOption = new NonTerminal("customQueryOption");
            var expand = new NonTerminal("expand");
            var filter = new NonTerminal("filter");
            var format = new NonTerminal("format");
            var inlinecount = new NonTerminal("inlinecount");
            var orderby = new NonTerminal("orderby");
            var search = new NonTerminal("search");
            var select = new NonTerminal("select");
            var skip = new NonTerminal("skip");
            var skiptoken = new NonTerminal("skiptoken");
            var top = new NonTerminal("top");
            var expandItems = new NonTerminal("expandItems");
            var levels = new NonTerminal("levels");
            var expandPath = new NonTerminal("expandPath");
            var expandRefOptions = new NonTerminal("expandRefOptions");
            var expandCountOptions = new NonTerminal("expandCountOptions");
            var expandOptions = new NonTerminal("expandOptions");
            var expandCountOption = new NonTerminal("expandCountOption");
            var expandRefOption = new NonTerminal("expandRefOption");
            var orderbyItems = new NonTerminal("orderbyItems");
            var searchExpr = new NonTerminal("searchExpr");
            var searchTerm = new NonTerminal("searchTerm");
            var searchAndExpr = new NonTerminal("searchAndExpr");
            var selectItems = new NonTerminal("selectItems");
            var allOperationsInSchema = new NonTerminal("allOperationsInSchema");
            var action = new NonTerminal("action");
            var _function = new NonTerminal("_function");
            var parameterNames = new NonTerminal("parameterNames");
            var parameterValue = new NonTerminal("parameterValue");
            var customName = new NonTerminal("customName");
            var queryOptions = new NonTerminal("queryOptions");
            var queryOption = new NonTerminal("queryOption");
            var expandItem = new NonTerminal("expandItem");
            var expandOption = new NonTerminal("expandOption");
            var orderbyItem = new NonTerminal("orderbyItem");
            var selectProperty = new NonTerminal("selectProperty");
            var parameterName = new NonTerminal("parameterName");
            var customValue = new NonTerminal("customValue");
            var selectOptionPC = new NonTerminal("selectOptionPC");
            var selectOption = new NonTerminal("selectOption");
            #endregion
            #region 2.1 System Query Option $apply Termianl
            var apply = new NonTerminal("apply");
            var applyExpr = new NonTerminal("applyExpr");
            var applyTrafo = new NonTerminal("applyTrafo");
            var aggregateTrafo = new NonTerminal("aggregateTrafo");
            var bottomcountTrafo = new NonTerminal("bottomcountTrafo");
            var bottompercentTrafo = new NonTerminal("bottompercentTrafo");
            var bottomsumTrafo = new NonTerminal("bottomsumTrafo");
            var computeTrafo = new NonTerminal("computeTrafo");
            var concatTrafo = new NonTerminal("concatTrafo");
            var expandTrafo = new NonTerminal("expandTrafo");
            var filterTrafo = new NonTerminal("filterTrafo");
            var groupbyTrafo = new NonTerminal("groupbyTrafo");
            var identityTrafo = new NonTerminal("identityTrafo");
            var searchTrafo = new NonTerminal("searchTrafo");
            var topcountTrafo = new NonTerminal("topcountTrafo");
            var toppercentTrafo = new NonTerminal("toppercentTrafo");
            var topsumTrafo = new NonTerminal("topsumTrafo");
            var customFunction = new NonTerminal("customFunction");
            var aggregateExpr = new NonTerminal("aggregateExpr");
            var asAlias = new NonTerminal("asAlias");
            var aggregateFrom = new NonTerminal("aggregateFrom");
            var aggregateWith = new NonTerminal("aggregateWith");
            var aggregateMethod = new NonTerminal("aggregateMethod");
            var groupingProperty = new NonTerminal("groupingProperty");
            var entityNavigationProperty = new NonTerminal("entityNavigationProperty");
            var primitiveProperty = new NonTerminal("primitiveProperty");
            var pathSegment = new NonTerminal("pathSegment");
            var navigationProperty = new NonTerminal("navigationProperty");
            var computeExpr = new NonTerminal("computeExpr");
            var groupbyList = new NonTerminal("groupbyList");
            var groupbyElement = new NonTerminal("groupbyElement");
            var rollupSpec = new NonTerminal("rollupSpec");
            var entityColFunction = new NonTerminal("entityColFunction");

            var groupbyElements = new NonTerminal("groupbyElements");
            var groupingPropertys = new NonTerminal("groupingPropertys");
            var computeExprs = new NonTerminal("computeExprs");
            var applyExprs = new NonTerminal("applyExprs");
            var expandfilterTrafos = new NonTerminal("expandfilterTrafos");
            var aggregateExprs = new NonTerminal("aggregateExprs");
            #endregion
            #region 4. Expressions Termianl
            var rootExpr = new NonTerminal("rootExpr");
            var firstMemberExpr = new NonTerminal("firstMemberExpr");
            var functionExpr = new NonTerminal("functionExpr");
            var parenExpr = new NonTerminal("parenExpr");
            var commonExpr = new NonTerminal("commonExpr");
            var memberPathExpr = new NonTerminal("memberPathExpr");
            var boolCommonExpr = commonExpr;
            var negateExpr = new NonTerminal("negateExpr");
            var methodCallExpr = new NonTerminal("methodCallExpr");
            var castExpr = new NonTerminal("castExpr");
            var addExpr = new NonTerminal("addExpr");
            var subExpr = new NonTerminal("subExpr");
            var mulExpr = new NonTerminal("mulExpr");
            var divExpr = new NonTerminal("divExpr");
            var modExpr = new NonTerminal("modExpr");
            var boolMethodCallExpr = new NonTerminal("boolMethodCallExpr");
            var notExpr = new NonTerminal("notExpr");
            var neExpr = new NonTerminal("neExpr");
            var ltExpr = new NonTerminal("ltExpr");
            var leExpr = new NonTerminal("leExpr");
            var gtExpr = new NonTerminal("gtExpr");
            var geExpr = new NonTerminal("geExpr");
            var hasExpr = new NonTerminal("hasExpr");
            var andExpr = new NonTerminal("andExpr");
            var orExpr = new NonTerminal("orExpr");
            var eqExpr = new NonTerminal("eqExpr");
            var isofExpr = new NonTerminal("isofExpr");
            var lambdaExpr = new NonTerminal("lambdaExpr");
            var anyExpr = new NonTerminal("anyExpr");
            var allExpr = new NonTerminal("allExpr");
            var indexOfMethodCallExpr = new NonTerminal("indexOfMethodCallExpr");
            var toLowerMethodCallExpr = new NonTerminal("toLowerMethodCallExpr");
            var toUpperMethodCallExpr = new NonTerminal("toUpperMethodCallExpr");
            var trimMethodCallExpr = new NonTerminal("trimMethodCallExpr");
            var substringMethodCallExpr = new NonTerminal("substringMethodCallExpr");
            var concatMethodCallExpr = new NonTerminal("concatMethodCallExpr");
            var lengthMethodCallExpr = new NonTerminal("lengthMethodCallExpr");
            var yearMethodCallExpr = new NonTerminal("yearMethodCallExpr");
            var monthMethodCallExpr = new NonTerminal("monthMethodCallExpr");
            var dayMethodCallExpr = new NonTerminal("dayMethodCallExpr");
            var hourMethodCallExpr = new NonTerminal("hourMethodCallExpr");
            var minuteMethodCallExpr = new NonTerminal("minuteMethodCallExpr");
            var secondMethodCallExpr = new NonTerminal("secondMethodCallExpr");
            var fractionalsecondsMethodCallExpr = new NonTerminal("fractionalsecondsMethodCallExpr");
            var totalsecondsMethodCallExpr = new NonTerminal("totalsecondsMethodCallExpr");
            var dateMethodCallExpr = new NonTerminal("dateMethodCallExpr");
            var timeMethodCallExpr = new NonTerminal("timeMethodCallExpr");
            var roundMethodCallExpr = new NonTerminal("roundMethodCallExpr");
            var floorMethodCallExpr = new NonTerminal("floorMethodCallExpr");
            var ceilingMethodCallExpr = new NonTerminal("ceilingMethodCallExpr");
            var distanceMethodCallExpr = new NonTerminal("distanceMethodCallExpr");
            var geoLengthMethodCallExpr = new NonTerminal("geoLengthMethodCallExpr");
            var totalOffsetMinutesMethodCallExpr = new NonTerminal("totalOffsetMinutesMethodCallExpr");
            var minDateTimeMethodCallExpr = new NonTerminal("minDateTimeMethodCallExpr");
            var maxDateTimeMethodCallExpr = new NonTerminal("maxDateTimeMethodCallExpr");
            var nowMethodCallExpr = new NonTerminal("nowMethodCallExpr");
            var endsWithMethodCallExpr = new NonTerminal("endsWithMethodCallExpr");
            var startsWithMethodCallExpr = new NonTerminal("startsWithMethodCallExpr");
            var containsMethodCallExpr = new NonTerminal("containsMethodCallExpr");
            var intersectsMethodCallExpr = new NonTerminal("intersectsMethodCallExpr");

            var singlePathExpr = new NonTerminal("singlePathExpr");
            var collectionPathExpr = new NonTerminal("collectionPathExpr");
            var functionExprContent = new NonTerminal("functionExprContent");
            var functionExprParameter = new NonTerminal("functionExprParameter");
            var functionExprParameters = new NonTerminal("functionExprParameters");
            #endregion
            #region 5. JSON format for function parameters Termianl
            var begin_object = ToTerm("{");
            var end_object = ToTerm("}");

            var begin_array = ToTerm("[");
            var end_array = ToTerm("]");

            var quotation_mark = DQUOTE;
            var name_separator = COLON;
            var value_separator = COMMA;

            var primitiveLiteralInJSON = new NonTerminal("primitiveLiteralInJSON");
            var arrayOrObject = new NonTerminal("arrayOrObject");
            var termName = new NonTerminal("termName");
            var arrayInUri = new NonTerminal("arrayInUri");
            var arrayItemsInUri = new NonTerminal("arrayItemsInUri");
            var complexInUri = new NonTerminal("complexInUri");
            var complexInUris = new NonTerminal("complexInUris");
            var objectPropertyInUri = new NonTerminal("objectPropertyInUri");
            #endregion
            #region 6. Names and identifiers Termianl
            var odataIdentifier = new IdentifierTerminal("odataIdentifier");
            odataIdentifier.SetFlag(TermFlags.NoAstNode);
            var qualifiedFullName = new NonTerminal("qualifiedFullName");
            var qualifiedTypeName = new NonTerminal("qualifiedTypeName");
            #endregion
            #region 7. Literal Data Values Terminal
            var numberInt = new NumberLiteral("number", NumberOptions.IntOnly);
            var booleanValue = ToTerm("true") | ToTerm("false");
            var dquoteString = new StringLiteral("dquoteString", "\"");
            var primitiveLiteral = new NonTerminal("primitiveLiteral");
            var binary = new NonTerminal("binary");
            var @null = new NonTerminal("null");
            var nullValue = new NonTerminal("nullValue");
            var numberLiteral = new NumberLiteral("numberLiteral");
            var stringLiteral = new StringLiteral("stringLiteral", "'");
            var guid = new NonTerminal("guid");
            var date = new NonTerminal("date");
            var dateTime = new NonTerminal("dateTime");
            var dateTimeOffset = new NonTerminal("dateTimeOffset");
            var timeOfDay = new NonTerminal("timeOfDay");
            var duration = new NonTerminal("duration");
            var @enum = new NonTerminal("enum");
            var enumValue = new NonTerminal("enumValue");
            var single_enumValue = new NonTerminal("single_enumValue");
            #endregion

            #region 1. Resource Path Rule
            resourcePath.Rule = boundOperation + objectPath.Q()
                | crossjoin
                | "$all";

            keyPredicate.Rule = OPEN + keyValuePairs + CLOSE;
            keyValuePairs.Rule = MakePlusRule(keyValuePairs, COMMA, keyValuePair);
            keyValuePair.Rule = (odataIdentifier + EQ).Q() + primitiveLiteral;

            count.Rule = SLASH + "$count";
            @ref.Rule = SLASH + "$ref";
            value.Rule = SLASH + "$value";
            //collectionPath singlePath complexPath
            objectPath.Rule = @ref | count | value | boundOperation_PropertyPath;
            //propertyPath boundOperation singleNavigation collectionNavigation
            boundOperation_PropertyPath.Rule = SLASH + boundOperation + objectPath.Q();

            boundOperation.Rule = qualifiedFullName + functionParameters.Q();

            functionParameters.Rule = OPEN + functionParameterList + CLOSE;
            functionParameterList.Rule = MakeStarRule(functionParameterList, COMMA, functionParameter);
            functionParameter.Rule = (odataIdentifier + EQ).Q() + (parameterAlias | primitiveLiteral);
            parameterAlias.Rule = AT + odataIdentifier;

            parameterName.Rule = odataIdentifier;

            crossjoin.Rule = "$crossjoin" + OPEN + crossjoinList + CLOSE;
            crossjoinList.Rule = MakePlusRule(crossjoinList, COMMA, odataIdentifier);
            #endregion
            #region 2. Query Options Rule
            queryOptions.Rule = MakePlusRule(queryOptions, AND, queryOption);
            queryOption.Rule = systemQueryOption
                         | aliasAndValue
                         | customQueryOption;

            entityOptions.Rule = MakeStarRule(entityOptions, AND, entityOption);
            entityOption.Rule = expand
                | id
                | format
                | select
                | customQueryOption;

            id.Rule = ToTerm("$id") + EQ + ODataTermianlFacotry.CreateCustomQueryOption("odataid");

            systemQueryOption.Rule = expand
                              | filter
                              | format
                              | id
                              | inlinecount
                              | orderby
                              | search
                              | select
                              | skip
                              | skiptoken
                              | apply
                              | top;

            expand.Rule = "$expand" + EQ + expandItems;
            expandItems.Rule = MakeStarRule(expandItems, COMMA, expandItem);
            expandItem.Rule = STAR + (@ref | OPEN + levels + CLOSE).Q()
                              | expandPath
                              + ((@ref | count) + (OPEN + expandRefOptions + CLOSE).Q()
                                | OPEN + expandOptions + CLOSE
                                ).Q();

            expandPath.Rule = MakePlusRule(expandPath, SLASH, qualifiedFullName);
            expandCountOptions.Rule = MakeStarRule(expandCountOptions, SEMI, expandCountOption);
            expandRefOptions.Rule = MakeStarRule(expandRefOptions, SEMI, expandRefOption);
            expandCountOption.Rule = filter
                              | search;
            expandRefOption.Rule = expandCountOption
                              | orderby
                              | skip
                              | top
                              | inlinecount;
            expandOptions.Rule = MakeStarRule(expandOptions, SEMI, expandOption);
            expandOption.Rule = expandRefOption
                              | select
                              | apply
                              | expand
                              | levels;

            levels.Rule = "$levels" + EQ + (numberInt | "max");

            filter.Rule = "$filter" + EQ + boolCommonExpr;

            orderby.Rule = "$orderby" + EQ + orderbyItems;
            orderbyItems.Rule = MakeStarRule(orderbyItems, COMMA, orderbyItem);
            orderbyItem.Rule = commonExpr + ((ToTerm("asc") | "desc")).Q();

            skip.Rule = "$skip" + EQ + numberInt;
            top.Rule = "$top" + EQ + numberInt;

            format.Rule = "$format" + EQ +
                      (ToTerm("atom")
                     | "json"
                     | "xml"
                     | odataIdentifier
                     );

            inlinecount.Rule = "$count" + EQ + booleanValue;

            search.Rule = "$search" + EQ + searchExpr;
            searchExpr.Rule = (OPEN + searchExpr + CLOSE
                         | searchTerm)
                         + (searchOrExpr | searchAndExpr).Q();

            searchOrExpr.Rule = "OR" + searchExpr;
            searchAndExpr.Rule = ToTerm("AND").Q() + searchExpr;

            searchTerm.Rule = ToTerm("NOT").Q() + (searchPhrase | searchWord);
            searchPhrase.Rule = dquoteString;
            searchWord.Rule = odataIdentifier;

            select.Rule = "$select" + EQ + selectItems;
            selectItems.Rule = MakeStarRule(selectItems, COMMA, selectItem);
            selectItem.Rule = STAR
                           | allOperationsInSchema
                           | selectProperty + (OPEN + parameterNames + CLOSE).Q();
            selectProperty.Rule = MakePlusRule(selectProperty, SLASH, qualifiedFullName);

            allOperationsInSchema.Rule = qualifiedFullName + "." + STAR;

            parameterNames.Rule = MakeStarRule(parameterNames, COMMA, parameterName);

            skiptoken.Rule = "$skiptoken" + EQ + odataIdentifier;

            aliasAndValue.Rule = parameterAlias + EQ + parameterValue;

            parameterValue.Rule = commonExpr;

            customQueryOption.Rule = customName + (EQ + customValue).Q();
            customName.Rule = ODataTermianlFacotry.CreateCustomQueryOption("customName");
            customValue.Rule = ODataTermianlFacotry.CreateCustomQueryOption("customValue");
            #endregion
            #region 2.1 System Query Option $apply Rule
            apply.Rule = "$apply" + EQ + applyExpr;
            applyExpr.Rule = MakePlusRule(applyExpr, SLASH, applyTrafo);
            applyTrafo.Rule = aggregateTrafo
                       | bottomcountTrafo
                       | bottompercentTrafo
                       | bottomsumTrafo
                       | computeTrafo
                       | concatTrafo
                       | expandTrafo
                       | filterTrafo
                       | groupbyTrafo
                       | identityTrafo
                       | searchTrafo
                       | topcountTrafo
                       | toppercentTrafo
                       | topsumTrafo
                       | customFunction
                       ;

            aggregateExprs.Rule = MakePlusRule(aggregateExprs, COMMA, aggregateExpr);
            aggregateTrafo.Rule = "aggregate" + OPEN + aggregateExprs + CLOSE;
            /*
             aggregateExpr   = customAggregate [ asAlias aggregateFrom ]
                / commonExpr aggregateWith asAlias [ aggregateFrom ]
                / pathPrefix '$count' asAlias 
                / pathPrefix customAggregate
                / pathPrefix pathSegment OPEN aggregateExpr CLOSE 

            由于以下两个产生式冲突，因此改写产生式如下
                commonExpr->memberPathExpr
                aggregateExpr->pathPrefix pathSegment OPEN aggregateExpr CLOSE 
             */
            aggregateExpr.Rule = (commonExpr | "$count") + aggregateWith.Q() + asAlias.Q() + aggregateFrom.Q();

            aggregateWith.Rule = "with" + aggregateMethod;
            aggregateFrom.Rule = "from" + groupingProperty + aggregateWith.Q() + aggregateFrom.Q();
            aggregateMethod.Rule = ToTerm("sum")
                            | "min"
                            | "max"
                            | "average"
                            | "countdistinct"
                            | qualifiedFullName;

            asAlias.Rule = "as" + odataIdentifier;

            groupingProperty.Rule = pathSegment;

            pathSegment.Rule = MakePlusRule(pathSegment, SLASH, qualifiedFullName);

            computeTrafo.Rule = "compute" + OPEN + computeExprs + CLOSE;
            computeExprs.Rule = MakePlusRule(computeExprs, COMMA, computeExpr);
            computeExpr.Rule = commonExpr + asAlias;

            bottomcountTrafo.Rule = "bottomcount" + OPEN + commonExpr + COMMA + commonExpr + CLOSE;
            bottompercentTrafo.Rule = "bottompercent" + OPEN + commonExpr + COMMA + commonExpr + CLOSE;
            bottomsumTrafo.Rule = "bottomsum" + OPEN + commonExpr + COMMA + commonExpr + CLOSE;

            applyExprs.Rule = MakePlusRule(applyExprs, COMMA, applyExpr);

            expandfilterTrafos.Rule = MakeStarRule(expandfilterTrafos, COMMA + (expandTrafo | filterTrafo));

            concatTrafo.Rule = "concat" + OPEN + applyExprs + CLOSE;
            expandTrafo.Rule = "expand" + OPEN + expandPath + expandfilterTrafos + CLOSE;
            filterTrafo.Rule = "filter" + OPEN + boolCommonExpr + CLOSE;
            searchTrafo.Rule = "search" + OPEN + searchExpr + CLOSE;

            groupbyTrafo.Rule = "groupby" + OPEN + groupbyList + (COMMA + applyExpr).Q() + CLOSE;
            groupbyList.Rule = OPEN + groupbyElements + CLOSE;
            groupbyElements.Rule = MakePlusRule(groupbyElements, COMMA, groupbyElement);
            groupbyElement.Rule = groupingProperty | rollupSpec;
            groupingPropertys.Rule = MakePlusRule(groupingPropertys, COMMA + groupingProperty);
            rollupSpec.Rule = "rollup" + OPEN + ("$all" | groupingProperty)
                          + groupingPropertys + CLOSE;

            identityTrafo.Rule = ToTerm("identity");

            topcountTrafo.Rule = "topcount" + OPEN + commonExpr + COMMA + commonExpr + CLOSE;
            toppercentTrafo.Rule = "toppercent" + OPEN + commonExpr + COMMA + commonExpr + CLOSE;
            topsumTrafo.Rule = "topsum" + OPEN + commonExpr + COMMA + commonExpr + CLOSE;

            customFunction.Rule = qualifiedFullName + OPEN + functionExprParameters + CLOSE;
            #endregion
            #region 4. Expressions Rule
            /*
             commonExpr = ( primitiveLiteral
                          / parameterAlias
                          / arrayOrObject
                          / rootExpr
                          / firstMemberExpr
                          / functionExpr
                          / negateExpr 
                          / methodCallExpr 
                          / parenExpr 
                          / castExpr 
                          ) 
                          [ addExpr 
                          / subExpr 
                          / mulExpr 
                          / divExpr 
                          / modExpr
                          ]  
            
             boolCommonExpr = ( isofExpr 
                              / boolMethodCallExpr 
                              / notExpr  
                              / commonExpr
                                [ eqExpr 
                                / neExpr 
                                / ltExpr  
                                / leExpr  
                                / gtExpr 
                                / geExpr 
                                / hasExpr 
                                ]
                              / boolParenExpr
                              ) [ andExpr / orExpr ] 
             解决 boolParenExpr 与 parenExpr 解析冲突
             */
            commonExpr.Rule = (primitiveLiteral
                     | parameterAlias
                     | arrayOrObject
                     | castExpr
                     | rootExpr
                     | firstMemberExpr
                     | memberPathExpr
                     | methodCallExpr
                     | isofExpr
                     | boolMethodCallExpr
                     | notExpr
                     | parenExpr
                     | negateExpr
                     )
                     + (addExpr | subExpr | mulExpr | divExpr | modExpr
                     | eqExpr | neExpr | ltExpr | leExpr | gtExpr | geExpr | hasExpr
                     | andExpr | orExpr
                     ).Q();

            parenExpr.Rule = OPEN + commonExpr + CLOSE;

            rootExpr.Rule = ToTerm("$root/") + odataIdentifier + keyPredicate.Q()
                + (singlePathExpr | collectionPathExpr).Q();

            firstMemberExpr.Rule = ToTerm("$it") + (SLASH + memberPathExpr).Q();

            collectionPathExpr.Rule = count
                        | SLASH + anyExpr
                        | SLASH + allExpr;
            singlePathExpr.Rule = SLASH + memberPathExpr;

            memberPathExpr.Rule = functionExpr + (singlePathExpr | collectionPathExpr).Q();

            functionExpr.Rule = qualifiedFullName + functionExprContent.Q();
            functionExprContent.Rule = OPEN + functionExprParameters + CLOSE;
            functionExprParameters.Rule = MakeStarRule(functionExprParameters, COMMA, functionExprParameter);
            functionExprParameter.Rule = parameterName + EQ + parameterValue | aggregateExpr;

            lambdaExpr.Rule = odataIdentifier + COLON + boolCommonExpr;
            anyExpr.Rule = ToTerm("any") + OPEN + lambdaExpr.Q() + CLOSE;
            allExpr.Rule = ToTerm("all") + OPEN + lambdaExpr + CLOSE;

            methodCallExpr.Rule = indexOfMethodCallExpr
               | toLowerMethodCallExpr
               | toUpperMethodCallExpr
               | trimMethodCallExpr
               | substringMethodCallExpr
               | concatMethodCallExpr
               | lengthMethodCallExpr
               | yearMethodCallExpr
               | monthMethodCallExpr
               | dayMethodCallExpr
               | hourMethodCallExpr
               | minuteMethodCallExpr
               | secondMethodCallExpr
               | fractionalsecondsMethodCallExpr
               | totalsecondsMethodCallExpr
               | dateMethodCallExpr
               | timeMethodCallExpr
               | roundMethodCallExpr
               | floorMethodCallExpr
               | ceilingMethodCallExpr
               | distanceMethodCallExpr
               | geoLengthMethodCallExpr
               | totalOffsetMinutesMethodCallExpr
               | minDateTimeMethodCallExpr
               | maxDateTimeMethodCallExpr
               | nowMethodCallExpr;

            boolMethodCallExpr.Rule = endsWithMethodCallExpr
                   | startsWithMethodCallExpr
                   | containsMethodCallExpr
                   | intersectsMethodCallExpr;

            containsMethodCallExpr.Rule = "contains" + OPEN + commonExpr + COMMA + commonExpr + CLOSE;
            startsWithMethodCallExpr.Rule = "startswith" + OPEN + commonExpr + COMMA + commonExpr + CLOSE;
            endsWithMethodCallExpr.Rule = "endswith" + OPEN + commonExpr + COMMA + commonExpr + CLOSE;
            lengthMethodCallExpr.Rule = "length" + OPEN + commonExpr + CLOSE;
            indexOfMethodCallExpr.Rule = "indexof" + OPEN + commonExpr + COMMA + commonExpr + CLOSE;
            substringMethodCallExpr.Rule = "substring" + OPEN + commonExpr + COMMA + commonExpr + (COMMA + commonExpr).Q() + CLOSE;
            toLowerMethodCallExpr.Rule = "tolower" + OPEN + commonExpr + CLOSE;
            toUpperMethodCallExpr.Rule = "toupper" + OPEN + commonExpr + CLOSE;
            trimMethodCallExpr.Rule = "trim" + OPEN + commonExpr + CLOSE;
            concatMethodCallExpr.Rule = "concat" + OPEN + commonExpr + COMMA + commonExpr + CLOSE;

            yearMethodCallExpr.Rule = "year" + OPEN + commonExpr + CLOSE;
            monthMethodCallExpr.Rule = "month" + OPEN + commonExpr + CLOSE;
            dayMethodCallExpr.Rule = "day" + OPEN + commonExpr + CLOSE;
            hourMethodCallExpr.Rule = "hour" + OPEN + commonExpr + CLOSE;
            minuteMethodCallExpr.Rule = "minute" + OPEN + commonExpr + CLOSE;
            secondMethodCallExpr.Rule = "second" + OPEN + commonExpr + CLOSE;
            fractionalsecondsMethodCallExpr.Rule = "fractionalseconds" + OPEN + commonExpr + CLOSE;
            totalsecondsMethodCallExpr.Rule = "totalseconds" + OPEN + commonExpr + CLOSE;
            dateMethodCallExpr.Rule = "date" + OPEN + commonExpr + CLOSE;
            timeMethodCallExpr.Rule = "time" + OPEN + commonExpr + CLOSE;
            totalOffsetMinutesMethodCallExpr.Rule = "totaloffsetminutes" + OPEN + commonExpr + CLOSE;

            minDateTimeMethodCallExpr.Rule = ToTerm("mindatetime(") + ")";
            maxDateTimeMethodCallExpr.Rule = ToTerm("maxdatetime(") + ")";
            nowMethodCallExpr.Rule = ToTerm("now(") + ")";

            roundMethodCallExpr.Rule = "round" + OPEN + commonExpr + CLOSE;
            floorMethodCallExpr.Rule = "floor" + OPEN + commonExpr + CLOSE;
            ceilingMethodCallExpr.Rule = "ceiling" + OPEN + commonExpr + CLOSE;

            distanceMethodCallExpr.Rule = "geo.distance" + OPEN + commonExpr + COMMA + commonExpr + CLOSE;
            geoLengthMethodCallExpr.Rule = "geo.length" + OPEN + commonExpr + CLOSE;
            intersectsMethodCallExpr.Rule = "geo.intersects" + OPEN + commonExpr + COMMA + commonExpr + CLOSE;

            isofExpr.Rule = ToTerm("isof") + OPEN + commonExpr + COMMA + qualifiedTypeName + CLOSE;
            castExpr.Rule = ToTerm("cast") + OPEN + commonExpr + COMMA + qualifiedTypeName + CLOSE;

            andExpr.Rule = ToTerm("and") + boolCommonExpr;
            orExpr.Rule = ToTerm("or") + boolCommonExpr;

            eqExpr.Rule = "eq" + commonExpr;
            neExpr.Rule = "ne" + commonExpr;
            ltExpr.Rule = "lt" + commonExpr;
            leExpr.Rule = "le" + commonExpr;
            gtExpr.Rule = "gt" + commonExpr;
            geExpr.Rule = "ge" + commonExpr;

            hasExpr.Rule = "has" + commonExpr;

            addExpr.Rule = "add" + commonExpr;
            subExpr.Rule = "sub" + commonExpr;
            mulExpr.Rule = "mul" + commonExpr;
            divExpr.Rule = "div" + commonExpr;
            modExpr.Rule = "mod" + commonExpr;

            negateExpr.Rule = ToTerm("-") + commonExpr;

            notExpr.Rule = "not" + boolCommonExpr;
            #endregion
            #region 5. JSON format for function parameters Rule
            arrayOrObject.Rule = arrayInUri
                          | complexInUri;

            arrayInUri.Rule = begin_array + arrayItemsInUri + end_array;
            arrayItemsInUri.Rule = MakeStarRule(arrayItemsInUri, value_separator, complexInUri | primitiveLiteralInJSON | rootExpr);

            complexInUri.Rule = begin_object + complexInUris + end_object;
            complexInUris.Rule = MakeStarRule(complexInUris, value_separator, objectPropertyInUri);

            objectPropertyInUri.Rule = quotation_mark + odataIdentifier + quotation_mark
                                  + name_separator
                                  + (arrayInUri
                                    | complexInUri
                                    | primitiveLiteralInJSON
                                    | rootExpr
                                  );

            primitiveLiteralInJSON.Rule = dquoteString
                               | numberLiteral
                               | booleanValue
                               | @null;
            #endregion
            #region 6. Names and identifiers
            qualifiedTypeName.Rule = qualifiedFullName
                          | "Collection" + OPEN + qualifiedFullName + CLOSE;

            qualifiedFullName.Rule = MakePlusRule(qualifiedFullName, DOT, odataIdentifier);
            #endregion
            #region 7. Literal Data Values
            primitiveLiteral.Rule = @null
                        | booleanValue
                        | guid
                        | date
                        | dateTime
                        | dateTimeOffset
                        | timeOfDay
                        | duration
                        | @enum
                        | binary
                        | numberLiteral
                        | stringLiteral;

            @null.Rule = nullValue + (SQUOTE + qualifiedTypeName + SQUOTE).Q();
            nullValue.Rule = "null";

            binary.Rule = (ToTerm("X") | "binary") + SQUOTE + ODataTermianlFacotry.CreateBinary("binaryValue") + SQUOTE;

            guid.Rule = ToTerm("guid") + SQUOTE + ODataTermianlFacotry.CreateGuid("guidValue") + SQUOTE;
            date.Rule = ToTerm("date") + SQUOTE + ODataTermianlFacotry.CreateDate("dateValue") + SQUOTE;
            dateTime.Rule = ToTerm("datetime") + SQUOTE + ODataTermianlFacotry.CreateDateTime("dateTimeValue") + SQUOTE;
            dateTimeOffset.Rule = ToTerm("datetimeoffset") + SQUOTE + ODataTermianlFacotry.CreateDateTimeOffset("dateTimeOffsetValue") + SQUOTE;
            timeOfDay.Rule = ToTerm("timeofday") + SQUOTE + ODataTermianlFacotry.CreateTimeOfDay("timeOfDayValue") + SQUOTE;
            duration.Rule = ToTerm("duration") + SQUOTE + ODataTermianlFacotry.CreateDuration("durationValue") + SQUOTE;

            @enum.Rule = ToTerm("enum") + qualifiedFullName + SQUOTE + enumValue + SQUOTE;
            enumValue.Rule = MakeStarRule(enumValue, COMMA, single_enumValue);
            single_enumValue.Rule = odataIdentifier | numberInt;
            #endregion

            // TODO: 3. Context URL Fragments
            // TODO: context
            odataRelativeUri.Rule = "$batch"
                | "$entity" + QUESTION + entityOptions
                | "$metadata" + (QUESTION + format).Q("metadataFormat") //[context]
                | resourcePath + (QUESTION + queryOptions).Q("resourceQuery");
            Root = odataRelativeUri;
        }
    }
}