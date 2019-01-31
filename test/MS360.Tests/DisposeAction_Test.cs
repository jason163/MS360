using MS;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MS360.Tests
{
    public class DisposeAction_Test
    {
        [Fact]
        public void Should_Call_Action_When_Disposed()
        {
            var actionIsCalled = false;

            using(new DisposeAction(()=> actionIsCalled = true))
            {

            }

            actionIsCalled.ShouldBe(true);
        }
    }
}
