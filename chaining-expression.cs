
            string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
            
            var param = Expression.Parameter(typeof(Tuple<int, string>), "param");
            Expression<Func<string, bool>> moreThan4Char = (string s) => s.Length > 4;
            Expression<Func<Tuple<int, string>, string>> extractValue = (Tuple<int, string> source) => source.Item2;

            var invoke = Expression.Invoke(moreThan4Char, Expression.Invoke(extractValue, param));

            var test = Expression.Lambda<Func<Tuple<int, string>, bool>>(invoke, param);


            var res = Summaries.Select((x, i) => new Tuple<int, string>(i, x)).AsQueryable().Where(test).ToArray();
            
