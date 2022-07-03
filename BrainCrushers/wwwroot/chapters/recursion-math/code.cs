#region Using statements
using System;
#endregion

namespace BrainCrushers;

#region Intro
public class Exercise
{
    public double Solve(Expression expression)
	{
#endregion
#region Solution
        return 0; // Fix me
#endregion
#region Outro
    }
#endregion
#region Expression
    public abstract class Expression
    {
        public static implicit operator Expression(double value)
        {
            return new Constant(value);
        }
#endregion
#region Expression Extra Code

#endregion
        #region Expression Outro
    }
#endregion
#region Constant
    public class Constant : Expression
    {
        public readonly double Value;

        public Constant(double value)
        {
            Value = value;
        }

        public override string ToString() => Value.ToString();
#endregion
#region Constant Extra Code

#endregion
#region Constant Outro
    }
#endregion
#region BinaryOperation
    public abstract class BinaryOperation : Expression
    {
        public readonly Expression FirstOperand;
        public readonly Expression SecondOperand;

        protected BinaryOperation(Expression firstOperand, Expression secondOperand)
        {
            FirstOperand = firstOperand ?? throw new ArgumentNullException(nameof(firstOperand));
            SecondOperand = secondOperand ?? throw new ArgumentNullException(nameof(secondOperand));
        }
#endregion
#region BinaryOperation Extra Code

#endregion
#region BinaryOperation Outro
    }
#endregion
#region Addition
    public class Addition : BinaryOperation
    {
        public Addition(Expression firstOperand, Expression secondOperand)
            : base(firstOperand, secondOperand)
        {
        }

        public override string ToString() => $"({FirstOperand} + {SecondOperand})";

#endregion
#region Addition Extra Code

#endregion
#region Addition Outro
    }
#endregion
#region Subtraction
    public class Subtraction : BinaryOperation
    {
        public Subtraction(Expression firstOperand, Expression secondOperand)
            : base(firstOperand, secondOperand)
        {
        }

        public override string ToString() => $"({FirstOperand} - {SecondOperand})";
#endregion
#region Subtraction Extra Code

#endregion
#region Subtraction Outro
    }
#endregion
#region Multiplication
    public class Multiplication : BinaryOperation
    {
        public Multiplication(Expression firstOperand, Expression secondOperand)
            : base(firstOperand, secondOperand)
        {
        }

        public override string ToString() => $"({FirstOperand} * {SecondOperand})";
#endregion
#region Multiplication Extra Code

#endregion
#region Multiplication Outro
    }
#endregion
#region Division
    public class Division : BinaryOperation
    {
        public Division(Expression firstOperand, Expression secondOperand)
            : base(firstOperand, secondOperand)
        {
        }

        public override string ToString() => $"({FirstOperand} / {SecondOperand})";
#endregion
#region Division Extra Code

#endregion
#region Division Outro
    }
}
#endregion
