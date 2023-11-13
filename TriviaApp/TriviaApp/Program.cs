using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Web;

namespace TriviaApp
{
    class TriviaResult
    {
        public string category;
        public string type;
        public string difficulty;
        public string question;
        public string correct_answer;
        public List<string> incorrect_answers;

    }
    class Trivia
    {
        public int response_code;
        public List<TriviaResult> results;
    }
    //response_code": 0,
     /* "results": [{
        "category": "Entertainment: Video Games","type": "multiple","difficulty": "medium",
        "question": "What character is NOT apart of the Grand Theft Auto series?",
        "correct_answer": "Michael Cardenas",
        "incorrect_answers": ["Packie McReary","Tommy Vercetti","Lester Crest"]
        }]}
     */
internal class Program
    {
        static void Main(string[] args)
        {
            string url = null;
            string s = null;

            HttpWebRequest request;
            HttpWebResponse response;
            StreamReader reader;

            url = "https://opentdb.com/api/php?amount=1";

            request = (HttpWebRequest)WebRequest.Create(url);
            response = (HttpWebResponse)request.GetResponse();
            reader = new StreamReader(response.GetResponseStream());
            s = reader.ReadToEnd();
            reader.Close();

            Trivia trivia = JsonConvert.DeserializeObject<Trivia>(s);

            trivia.results[0].question = HttpUtility.HtmlDecode(trivia.results[0].question);////
            trivia.results[0].correct_answer = HttpUtility.HtmlDecode(trivia.results[0].correct_answer);

            for (int i = 0; i < trivia.results[0].incorrect_answers.Count; ++i)
            {
                trivia.results[0].incorrect_answers[i] = HttpUtility.HtmlDecode(trivia.results[0].incorrect_answers[i]);
            }

        }
    }
}

/*
 * // 20231113153632
// https://opentdb.com/api.php?amount=1

{
  "response_code": 0,
  "results": [
    {
      "category": "Entertainment: Video Games",
      "type": "multiple",
      "difficulty": "medium",
      "question": "What character is NOT apart of the Grand Theft Auto series?",
      "correct_answer": "Michael Cardenas",
      "incorrect_answers": [
        "Packie McReary",
        "Tommy Vercetti",
        "Lester Crest"
      ]
    }
  ]
}
*/
