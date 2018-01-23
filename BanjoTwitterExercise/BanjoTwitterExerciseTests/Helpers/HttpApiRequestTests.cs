using Microsoft.VisualStudio.TestTools.UnitTesting;
using BanjoTwitterExercise.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace BanjoTwitterExercise.Helpers.Tests
{
    [TestClass()]
    public class HttpApiRequestTests
    {
        [TestMethod()]
        public void GetParametersAsQueryStringParameteIsNullTest()
        {
            //arrange
            var mockHeader = new Mock<IHttpRequestHeader>();
            var httpApiRequest = new HttpApiRequest<string>(Enums.APIsListEnum.SearchForTweets, mockHeader.Object);

            //act
            var actual = httpApiRequest.GetParametersAsQueryString();
            string expected = null;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void GetParametersAsQueryStringParameteIsNotNullTest()
        {
            //arrange
            var mockHeader = new Mock<IHttpRequestHeader>();
            var mockApiParameter = new Mock<List<IApiParameter>>();
            var mockHeader1 = Mock.Of<IApiParameter>();
            mockHeader1.Name = "q";
            mockHeader1.Value = "#test";
            var mockHeader2 = Mock.Of<IApiParameter>();
            mockHeader2.Name = "count";
            mockHeader2.Value = "100";
            var mockHeaderList = new List<IApiParameter>();
            mockHeaderList.Add(mockHeader1);
            mockHeaderList.Add(mockHeader2);
            var httpApiRequest = new HttpApiRequest<string>(Enums.APIsListEnum.SearchForTweets, mockHeaderList, mockHeader.Object);

            //act
            var result = httpApiRequest.GetParametersAsQueryString();
            string expected = "q=%23test&count=100";
            Assert.AreEqual(result, expected);
        }
    }
}