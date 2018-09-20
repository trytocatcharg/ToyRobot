using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit;
using NUnit.Framework;
using ToyRobot.Service;
using FluentAssertions;


namespace ToyRobot.Tests.Service
{
    [TestFixture]
    public class RobotServiceTest
    {

        [Test]
		public void Movement_InvalidPlaceCommand_ThrowEx()
        {
			//arrange
            var sut = new RobotService();

            //act
            Action act = () => sut.Compute("NO_COMMAND 1,2,EAST");

            //assert
            act.ShouldThrow<Exception>();
        }


        [Test]
        public void Movement_InvalidNumberX_ThrowEx()
        {
            //arrange
            var sut = new RobotService();

            sut.Compute("PLACE NUMBER_X,2,EAST");

            //act
            Action act = () => sut.Movement();

            //assert
            act.ShouldThrow<Exception>();
        }

        [Test]
        public void Movement_InvalidNumberY_ThrowEx()
        {
            //arrange
            var sut = new RobotService();
            sut.Compute("PLACE 2,X,EAST");

            //act
            Action act = () => sut.Movement();

            //assert
            act.ShouldThrow<Exception>();
        }

        [Test]
        public void Movement_InvalidNumberY_InMiddle_ThrowEx()
        {
            //arrange
            var sut = new RobotService();
            sut.Compute("PLACE 2,2,EAST");
            sut.Compute("MOVE");
            sut.Compute("PLACE 2,X,EAST");

            //act
            Action act = () => sut.Movement();

            //assert
            act.ShouldThrow<Exception>();
        }

        [Test]
        public void Movement_InvalidNumberX_InMiddle_ThrowEx()
        {
            //arrange
            var sut = new RobotService();
            sut.Compute("PLACE 2,2,EAST");
            sut.Compute("MOVE");
            sut.Compute("PLACE x,2,EAST");

            //act
            Action act = () => sut.Movement();

            //assert
            act.ShouldThrow<Exception>();
        }

        [Test]
        public void Movement_InvalidInitialDirectionCommand_ThrowEx()
        {
            //arrange
            var sut = new RobotService();
            sut.Compute("PLACE 1,2,DEEP");

            //act
            Action act = () => sut.Movement();

            //assert
            act.ShouldThrow<Exception>();
        }

        [Test]
        public void Movement_InvalidMovementCommand_ThrowEx()
        {
            //arrange
            var sut = new RobotService();
            sut.Compute("PLACE 1,2,NORTH");

            //act
            Action act = () => sut.Compute("STAY");

            //assert
            act.ShouldThrow<Exception>();
        }


        [Test]
        public void Movement_InvalidInitialPositionCommand_ThrowEx()
        {
            //arrange
            var sut = new RobotService();
            sut.Compute("PLACE 99,99,NORTH");

            //act
            Action act = () => sut.Movement();

            //assert
            act.ShouldThrow<Exception>();
        }

        [Test]
        public void Movement_ValidMoveResultCommand1_ResultValid()
        {
            //arrange
            var sut = new RobotService();
            sut.Compute("PLACE 1,1,NORTH");
            sut.Compute("MOVE");
            sut.Compute("MOVE");

            //act
            var result= sut.Movement();

            //assert
            Assert.AreEqual(result.AxisX, 1);
            Assert.AreEqual(result.AxisY, 3);
            Assert.AreEqual(result.Facing, "NORTH");
        }


        [Test]
        public void Movement_ValidMoveResultCommand2_ResultValid()
        {
            //arrange
            var sut = new RobotService();
            sut.Compute("PLACE 1,2,EAST");
            sut.Compute("MOVE");
            sut.Compute("MOVE");
            sut.Compute("LEFT");
            sut.Compute("MOVE");
            
            //act
            var result = sut.Movement();

            //assert
            Assert.AreEqual(result.AxisX, 3);
            Assert.AreEqual(result.AxisY, 3);
            Assert.AreEqual(result.Facing, "NORTH");
        }

        [Test]
        public void Movement_ValidMoveResultCommand3_ResultValid()
        {
            //arrange
            var sut = new RobotService();
            sut.Compute("PLACE 1,2,EAST");
            sut.Compute("MOVE");
            sut.Compute("MOVE");
            sut.Compute("LEFT");
            sut.Compute("LEFT");
            sut.Compute("MOVE");

            //act
            var result = sut.Movement();

            //assert
            Assert.AreEqual(result.AxisX, 2);
            Assert.AreEqual(result.AxisY, 2);
            Assert.AreEqual(result.Facing, "WEST");
        }




    }
}
