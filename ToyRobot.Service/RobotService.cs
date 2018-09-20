using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToyRobot.Service.Commands;
using ToyRobot.Service.Enum;
using ToyRobot.ViewModel;

namespace ToyRobot.Service
{
    public class RobotService : IRobotService
    {
        const int ColumnIndex= 5;
        const int RowIndex = 5;

        private int[,] MatrixRobot { get; set; }

        private List<ICommand> CommandList;
        private Int32 CurrentRow;
        private Int32 CurrentColumn;

        private FacingOrientation Currentfacing { get; set; }
        private ValidationRobot validation { get; set; }

        public RobotService()
        {
            MatrixRobot = new int[RowIndex, ColumnIndex];
            validation = new ValidationRobot();
            CommandList = new List<ICommand>();
        }


        public ToyRobotDetailViewModel Movement()
        {
            ToyRobotDetailViewModel newPosition=null;
            if (CommandList.Any())
            {
                //Currentfacing= (FacingOrientation)System.Enum.Parse(typeof(FacingOrientation), firtCommandCoord[2].ToString());
                //CurrentColumn= Convert.ToInt32(firtCommandCoord[0]);
                //CurrentRow = Convert.ToInt32(firtCommandCoord[1]);
                //MatrixRobot[CurrentRow, CurrentColumn] = 1;
                foreach (var commandToExecute in CommandList)
                {
                    newPosition= commandToExecute.Execute(CurrentColumn, CurrentRow, MatrixRobot, Currentfacing);

                    if (validation.ValidPosition(newPosition.AxisX,newPosition.AxisY,MatrixRobot))
                    {
                        //reset olrder position
                        MatrixRobot[CurrentRow, CurrentColumn] = 0;
                        //assign new
                        MatrixRobot[newPosition.AxisY, newPosition.AxisX] = 1;

                        CurrentColumn = newPosition.AxisX;
                        CurrentRow = newPosition.AxisY;
                        Currentfacing = (FacingOrientation)System.Enum.Parse(typeof(FacingOrientation), newPosition.Facing);
                    }
                    
                }
            }

  
            CommandList.Clear();

            return newPosition;
        }

        private ToyRobotDetailViewModel GenerateMovement(int[,] matrixRobot, 
                                                        int currentRow, 
                                                        int currentColumn, 
                                                        FacingOrientation currentfacing, 
                                                        FacingDirection facingDirection)
        {
            int indexToMove = 1;
            var newDirection = currentfacing;
            int indexDirection=0;
            switch (facingDirection)
            {
                //case FacingDirection.Move:
                   
                //    break;
                case FacingDirection.LEFT:
                    indexDirection = (int)Currentfacing;
                    indexDirection = indexDirection - 1;
                    if (indexDirection < 0) indexDirection = System.Enum.GetValues(typeof(FacingOrientation)).Cast<int>().Max();

                    newDirection = (FacingOrientation)indexDirection;
                    break;
                case FacingDirection.RIGHT:
                    
                    var maxEnum= System.Enum.GetValues(typeof(FacingOrientation)).Cast<int>().Max();

                    indexDirection = (int)Currentfacing;
                    indexDirection = indexDirection + 1;
                    if (indexDirection > maxEnum) indexDirection = 0;

                    newDirection = (FacingOrientation)indexDirection;
                    break;
                default:

                    if (Currentfacing == FacingOrientation.WEST
                         || Currentfacing == FacingOrientation.SOUTH)
                        indexToMove = -1;

                    //north and south --> move between rows
                    if (newDirection == FacingOrientation.NORTH
                                || newDirection == FacingOrientation.SOUTH)
                    {
                        currentRow = currentRow + indexToMove;
                    }
                    else
                    {
                        //west and east --> move between columns
                        currentColumn = currentColumn + indexToMove;
                    }

                    break;
            }

          

            //TODO validate correct position

            return new ToyRobotDetailViewModel
            {
                AxisX = currentColumn,
                AxisY = currentRow,
                Facing = newDirection.ToString()
            };

        }

        public void Compute(string commandLine)
        {
            var reciever = new ParseCommand();
            
            //Add all the command
            CommandList.Add(reciever.Action(commandLine));
   
       }

    }
}
