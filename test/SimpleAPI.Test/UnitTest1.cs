using Microsoft.AspNetCore.Mvc;
using Xunit;
using System;
using SimpleAPI.Controllers;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace SimpleAPI.Test;

public class UnitTest1 
{      
    [Fact]
    public void GetListWithILogger(){
    using (var loggerFactory = new LoggerFactory())   // Need to use "using" in order to flush Console output
        {
            var logger = loggerFactory.CreateLogger<WeatherForecastController>();
            var svc = new WeatherForecastController(logger);
            var result = svc.Get();
             List<string>ar = new List<string>();
            foreach(WeatherForecast wf in result){
                ar.Add(wf.Summary);
            }
            //Assert.True(ar.Contains("Freezing"));

            var z = result.Select( x => x.Summary);
            Assert.True(z.Contains("Freezing"));
        }
    }

/*
     [Fact]
    public void TestGetIdWithILoggerTest(){

            var svc = new WeatherForecastController();
            var result = svc.Get(4).Value;
            Assert.Equal(8, result);
        
    }
*/

    [Fact]
    public void TestGetIdWithILogger(){
    using (var loggerFactory = new LoggerFactory())   // Need to use "using" in order to flush Console output
        {
            var logger = loggerFactory.CreateLogger<WeatherForecastController>();
            var svc = new WeatherForecastController(logger);
            var result = svc.Get(4).Value;
            Assert.Equal(8, result);
        }
    }
    /*WeatherForecastController controller = new WeatherForecastController();
    [Fact]
    public void TestGetId()
    {
        var returnedVal = controller.Get(4);
        Assert.Equal(8,returnedVal.Value);
    }
*/
}