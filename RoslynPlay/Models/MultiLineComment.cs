﻿using System.Text.RegularExpressions;

namespace RoslynPlay
{
    class MultiLineComment : Comment
    {
        public MultiLineComment(string content, int lineStart, int lineEnd, CommentLocationStore commentLocationstore)
        {
            Content = new Regex(@"\/\*(.*)\*\/", RegexOptions.Singleline).Match(content).Groups[1].ToString();
            Type = "multi_line_comment";
            LineStart = lineStart;
            LineEnd = lineEnd;
            Metrics = new Metrics(Content, lineEnd, Type, commentLocationstore);
            Evaluation = new EvaluationBad(Metrics);
        }

        public override string GetLinesRange()
        {
            return $"{LineStart}-{LineEnd}";
        }
    }
}
