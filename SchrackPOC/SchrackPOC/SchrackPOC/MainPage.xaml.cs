using Couchbase.Lite;
using Couchbase.Lite.DI;
using Couchbase.Lite.Query;
using Couchbase.Lite.Sync;
using SchrackPOC.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SchrackPOC
{
    public partial class MainPage : ContentPage
    {
        #region Constants

      //  private const string DbName = "testdb";
        private const string DbName = "monkeydb";
        private const string username = "rachel";
        private const string password = "pass";
        private const string channel1 = "channel1";
        private const string channel2 = "channel2";
        private const string channel3 = "user";
        private string[] channels =  new string[] { channel1, channel2,channel3 };
        bool isGuest = false;
        private const string docID = "Doc8";
        private const string dictonaryID = "SampleHTML";
        //private static readonly Uri SyncUrl = new Uri("ws://localhost:4984");
        private Uri SyncUrl;
        
        string scriptText;// = System.IO.File.ReadAllText(@"myscript.js");
        string styleText;

        #endregion
        Database db;
        //string sampleHTML = "<!DOCTYPE html><html><head></head><body><h2> Book Heading </h2><p id='p1'> This is a sample paragraph. This is a sample paragraph.This is a sample paragraph.This is a sample paragraph.This is a sample paragraph.</p></body></html>";

        string modified1HTML = "<!DOCTYPE html><html><head></head><body><h2> Modified 1 Book Heading </h2><p id='p1'> This is a modified 1 sample paragraph. This is a modified 1 sample paragraph.This is modified 1 sample paragraph.</p></body></html>";
        string modified2HTML = "<!DOCTYPE html><html><head></head><body><h2> Modified 2 Book Heading </h2><p id='p1'> This is a modified 2 sample paragraph. This is a modified 2  sample paragraph.This is modified 2 sample paragraph.</p></body></html>";
        string sampleHTML = "<html> <head> <title> </title> <link rel=\"stylesheet\" type=\"text/css\" href=\"style2.css\"> </head> <body data-type=\"book\"> <div class=\"page\"> <h1>2016 Indian Line of Control strike</h1> <section data-type=\"chapter\"> <h1>Chapter one</h1> <section data-type=\"sect1\"> <h1>A-Head</h1> <p>On 29 September, eleven days after the Uri attack, the Indian Army conducted surgical strikes against suspected militants in Pakistani-administered Kashmir. Lt Gen Ranbir Singh, Indian Director General of Military Operations (DGMO), said that it had received \"very credible and specific information\" about \"terrorist teams\" who were preparing to \"carry out infiltration and conduct terrorist strikes inside Jammu and Kashmir and in various metros in other states\". The Indian action was meant to pre-empt their infiltration.[22][23] India presented its operation as preemptive self-defence against terrorism, striking against terrorist infrastructure along with \"those who are trying to support them.\" Columnist Ankit Panda thought the latter included Pakistani soldiers or the elements of Pakistani state.[33] On 30 September, Indian minister for information and broadcasting Rajyavardhan Singh Rathore said that there had been no aerial strikes and that the operation had been conducted \"on the ground\".[34][35] Ranbir Singh said that his Pakistani counterpart had been informed.[2] The Pakistani military said the DGMO communications discussed only the cross-border firing, which was part of the existing rules of engagement.[36] Pakistan denied that such surgical strikes occurred. The Inter-Services Public Relations said that there had been only \"cross border firing\".[33] But, Pakistan Prime Minister Nawaz Sharif condemned the \"unprovoked and naked aggression of Indian forces\", and said that Pakistani military was capable of thwarting any attacks by India.[22][37] UN Secretary General Ban Ki-Moon said that the UN Observer Group in Pakistani Kashmir did not directly observe any \"firing across the Line of Control\" relating to the incident.[38][39] The Indian envoy at UN Syed Akbaruddin dismissed this statement, saying \"facts on the ground do not change whether somebody acknowledges or not.\"[39] Analyst Sandeep Singh, writing in The Diplomat, said that the operation is better characterised as a cross-border raid because \"surgical strikes\" involve striking deep into the enemy territory and typically using air power.[40] Shaun Snow writing in The Diplomat questioned whether India had the capacity to conduct a \"surgical strike\", noting that Pakistan has a very comprehensive and modern air defence system. [41] A cross border raid, if it occurred 1km into Pakistani administered territory, is routine on either side with over a dozen incidents having occurred both ways[42], and does not qualify as a \"surgical strike\" which by definition requires deep striking and air power as Sandeep Singh, cited earlier, attests to. </p> </section> </section> </div> <div class=\"page\"> <section data-type=\"sect2\"> <h2>B-Head</h2> <table border=\"1px solid\"> <caption>State capitals</caption> <tr> <th>State</th> <th>Capital</th> </tr> <tr> <td>Maharashtra</td> <td>Mumbai</td> </tr> <tr> <td>Uttar Pradesh</td> <td>Lucknow</td> </tr> <tr> <td>Kerala</td> <td>Thiruvananthapuram</td> </tr> <tr> <td>Jammu and Kashmir</td> <td>Srinagar</td> </tr> <tr> <td>Rajasthan</td> <td>Jaipur</td> </tr> <!-- And so on --> </table> <p> Indian officials said the strike targeted areas close to the Line of Control (LoC), where it believes militants congregate for their final briefings before sneaking across the LoC. An Indian security source said the operation began with Indian forces firing artillery across the frontier to provide cover for three to four teams of 70–80 soldiers from the 4th and 9th battalions of the Parachute Regiment (Special Forces) to cross the LoC at several separate points shortly after midnight IST on 29 September (18:30 hours UTC, 28 Sep). Teams from 4 Para crossed the LoC in the Nowgam sector of Kupwara district, while teams from 9 Para simultaneously crossed the LoC in Poonch district.[3][2] By 2 a.m. IST, according to army sources, the special forces teams had travelled 1–3 km on foot, and had begun destroying terrorist bases with hand-held grenades and 84 mm rocket launchers. The teams then swiftly returned to the Indian side of the Line of Control, suffering only one casualty, a soldier wounded after tripping a land mine.[3] The Indian Army said the strike was a pre-emptive attack on militant bases, claiming that it had received intelligence that the militants were planning \"terrorist strikes\" against India.[22][23] India said that, in destroying \"terrorist infrastructure\" it also attacked \"those who are trying to support them\", indicating it attacked Pakistani soldiers too.[33] India later briefed opposition parties and foreign envoys, but did not disclose operational details.[2] Some Indian media claimed that the Indian army infiltrated 2–3 km into Pakistani territory,[16] but the Indian Army did not say whether its troops crossed the border or had simply fired across it.[22] India said that none of its soldiers were killed though two soldiers were injured.[2] It also stated that one of its soldiers, from 37 Rashtriya Rifles, was captured by Pakistan after he \"inadvertently crossed over to the Pakistan side\", though not during the \"surgical strikes.\"[20] Initially, Indian media claimed that the army used helicopters during the skirmish. On 30 September, an Indian minister denied that there were any helicopters used, stating the operation was conducted \"on the ground\".[34][35] On 18 September 2016, a fedayeen attack was made by four armed militants on an army base near the town of Uri. Nineteen Indian Army soldiers were killed. India accused Jaish-e-Muhammad, a Pakistan-based terrorist organisation.[26] Having come after similar fidayeen attacks in Gurdaspur and Pathankot, the Uri attack gave rise to high degree of concern in India.[27] The following day, the Indian army said that it had displayed considerable restraint in the wake of the attacks, but it reserved the right to respond \"at the time and place of our own choosing.”.[28] The Guardian said that Indian patience had run out due to Pakistan's inaction in curbing the activities of terrorist organisations such as Lashkar-e-Taiba and Jaish-e-Mohammad.[29] On 21 September, India summoned the Pakistan High Commission Abdul Bassit and gave a protest letter detailing the involvement of a terrorist group based in Pakistan.[30] Pakistan later said that India had provided no evidence that the Uri attack was launched from Pakistan. Pakistan's defence minister suggested that India had carried out the Uri attack to deflect attention from the popular protests in Jammu and Kashmir.[29] The Hindustan Times reported that the minister's comments made up an \"inflection point\", after which India decided to respond militarily.[30] Indian officials said that the cross-border infiltration across the Line of Control had surged since the unrest began in Kashmir. The persons crossing the border showed evidence of military training.[31] According to a government source close to Home Minister Rajnath Singh, a meeting of the Cabinet Committee on Security was held on 24 September, at which \"broad details of targeting terrorists\" were discussed.[32] </p> <!-- And so on... --> </section> </div> <div class=\"page\"> <section data-type=\"chapter\"> <h1>Chapter two</h1> <section data-type=\"sect3\"> <h1>Indian version</h1> <img src='surgical.jpg' alt='title' /> <p> Indian officials said the strike targeted areas close to the Line of Control (LoC), where it believes militants congregate for their final briefings before sneaking across the LoC. An Indian security source said the operation began with Indian forces firing artillery across the frontier to provide cover for three to four teams of 70–80 soldiers from the 4th and 9th battalions of the Parachute Regiment (Special Forces) to cross the LoC at several separate points shortly after midnight IST on 29 September (18:30 hours UTC, 28 Sep). Teams from 4 Para crossed the LoC in the Nowgam sector of Kupwara district, while teams from 9 Para simultaneously crossed the LoC in Poonch district.[3][2] By 2 a.m. IST, according to army sources, the special forces teams had travelled 1–3 km on foot, and had begun destroying terrorist bases with hand-held grenades and 84 mm rocket launchers. The teams then swiftly returned to the Indian side of the Line of Control, suffering only one casualty, a soldier wounded after tripping a land mine.[3] The Indian Army said the strike was a pre-emptive attack on militant bases, claiming that it had received intelligence that the militants were planning \"terrorist strikes\" against India.[22][23] India said that, in destroying \"terrorist infrastructure\" it also attacked \"those who are trying to support them\", indicating it attacked Pakistani soldiers too.[33] India later briefed opposition parties and foreign envoys, but did not disclose operational details.[2] Some Indian media claimed that the Indian army infiltrated 2–3 km into Pakistani territory,[16] but the Indian Army did not say whether its troops crossed the border or had simply fired across it.[22] India said that none of its soldiers were killed though two soldiers were injured.[2] It also stated that one of its soldiers, from 37 Rashtriya Rifles, was captured by Pakistan after he \"inadvertently crossed over to the Pakistan side\", though not during the \"surgical strikes.\"[20] Initially, Indian media claimed that the army used helicopters during the skirmish. On 30 September, an Indian minister denied that there were any helicopters used, stating the operation was conducted \"on the ground\".[34][35] </p> </section> </section> </div> </body></html>";
        string htmlstring = "html";
        IList<string> storedSelection;
        MutableArrayObject previousSelections;

        public MainPage()
        {
            InitializeComponent();
            //txtIP.Text = "ws://10.175.174.88:4984";
            txtIP.Text = "ws://10.127.126.132:4984"; //VM server
            storedSelection = new List<string>();
            LoadData();
            InitializeDatabase();
            Title = "Electromagnetic Compatibility";
        }


        private void LoadData()
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MainPage)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("SchrackPOC.myscript.js");
            string text = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }
            scriptText = text;
            Stream styleStream = assembly.GetManifestResourceStream("SchrackPOC.style.css");            
            using (var reader = new System.IO.StreamReader(styleStream))
            {
                styleText = reader.ReadToEnd();
            }
        }
        private void LoadHTMLFile()
        {
            var htmlSource = new HtmlWebViewSource();

            htmlSource.Html = @"<html>
                                    <head>
                                        <link rel=""stylesheet"" href=""default.css"">
                                    </head>
                                    <body>
                                        <h1>Xamarin.Forms</h1>
                                        <p>The CSS and image are loaded from local files!</p>
                                        <img src='XamarinLogo.png'/>
                                        <p><a href=""local.html"">next page</a></p>
                                    </body>
                                </html>";

            htmlSource.BaseUrl = DependencyService.Get<IBaseUrl>().Get();
            webView.Source = htmlSource;
        }

        private void InitializeDatabase()
        {
            var options = new DatabaseConfiguration();
            // Borrow this functionality from Couchbase Lite
            var defaultDirectory = Couchbase.Lite.DI.Service.GetInstance<IDefaultDirectoryResolver>().DefaultDirectory();
            //.Provider.GetService<IDefaultDirectoryResolver>().DefaultDirectory();
            var userFolder = Path.Combine(defaultDirectory, "testUser");
            if (!Directory.Exists(userFolder))
            {
                Directory.CreateDirectory(userFolder);
            }

            options.Directory = userFolder;
            Debug.WriteLine($"Will open/create DB at path {userFolder}");
            if (!Database.Exists(DbName, userFolder))
            {
                db = new Database(DbName, options);
                // Load prebuilt database to path
                //var copier = Couchbase.Lite.DI.Service.GetInstance<IDatabaseSeedService>();
                //await copier.CopyDatabaseAsync(userFolder);
                //db = new Database(DbName, options);
                //CreateDatabaseIndexes(db);
            }
            else
            {
                db = new Database(DbName, options);
            }

            //}
            //  CreateNewDocument(db);

            //var repl = isGuest ? default(Replicator) : StartReplication(username, password, db);

            //return new CouchbaseSession(db, repl, username);


            var repl = isGuest ? default(Replicator) : PushDatabase(username, password, db);

            CreateFirstDocument();
            UpdateHTML();
            //CreateSecondDocument();
            CreateDatabaseIndex();
        }

        private void UpdateHTML()
        {
            var htmlSource = new HtmlWebViewSource
            {
                Html = HtmlString()
            };
            webView.Source = htmlSource;
        }

        private void CreateFirstDocument()
        {
            if (db != null && db.GetDocument(docID) == null)
            {
                // Create a new document (i.e. a record) in the database
                string id = docID;
                IDictionary<string, object> dictionary = new Dictionary<string, object>();

                //dictionary.Add("simpleHtml", "<!DOCTYPE html><html><head><title> Page Title </title ></head><body><h1> Shrack For Student </h1><h2> Book Heading </h2><p> This is a sample paragraph. This is a sample paragraph.This is a sample paragraph.This is a sample paragraph.This is a sample paragraph.</p></body></html>");
                //dictionary.Add("SampleHtml", sampleHTML);
                dictionary.Add(dictonaryID, sampleHTML);

                //if (db.GetDocument("htmlData") == null)
                    if (db.GetDocument(docID) == null)
                    using (var mutableDoc = new MutableDocument(id, dictionary))
                    {
                        mutableDoc.SetFloat("version", 1.0f)
                            .SetString("type", "HTML")
                            //.SetString("channels", channel1);
                            .SetString("channels", $"channel.{username}");
                        // Save it to the database  
                        db.Save(mutableDoc);
                    }
            }
        }

        void Delete_Clicked(object sender, System.EventArgs e)
        {
            if (db != null)
            {
                Document doc = db.GetDocument(docID);
                 if( doc != null)
                    {
                            db.Delete(doc);
                    }
            }
            UpdateHTML();
        }

        void Create1_Clicked(object sender, System.EventArgs e)
        {
            CreateFirstDocument();
            UpdateHTML();
        }

        void Create2_Clicked(object sender, System.EventArgs e)
        {
            CreateSecondDocument();
            UpdateHTML();
        }

        public string HtmlString()
        {
            if (db.GetDocument(docID) != null)
            {
                htmlstring = db.GetDocument(docID).GetString("SampleHTML");
                htmlstring = htmlstring.Replace("<head>", "<head> <link href = 'https://cdn.jsdelivr.net/npm/froala-editor@2.9.3/css/froala_editor.min.css' rel = 'stylesheet' type = 'text/css'/> " +
                    "<link href = 'https://cdn.jsdelivr.net/npm/froala-editor@2.9.3/css/froala_style.min.css' rel = 'stylesheet' type = 'text/css'/> <style>" + styleText + "</style>");
                htmlstring = htmlstring.Replace("<body", "<body onload='addKey(document.body)'");
                htmlstring = htmlstring.Replace("</body>", "<script src='https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js'></script> <script>" + scriptText + "</script> </body>");


                /* using (var query = QueryBuilder.Select(SelectResult.All())
                     .From(DataSource.Database(db))
                     .Where(Expression.Property("type").EqualTo(Expression.String("HTML"))))
                     {
                         // Run the query
                         var result = query.Execute().AllResults();
                         foreach (var record in result)
                         {                    
                             var data = record.GetDictionary(0);                    
                             htmlstring = data.GetValue(dictonaryID).ToString();
                         }
                         Console.WriteLine($"Number of rows :: {result.Count()}");
                     }*/
            }

            else
            {
                htmlstring = "";
            }
            return htmlstring;
        }

        void ModifyHTML1_Clicked(object sender, System.EventArgs e)
        {
            //using (var document = db.GetDocument("htmlData"))
            using (var document = db.GetDocument(docID))
            {
                using (var mutableDocument = document.ToMutable())
                {
                    //mutableDocument.SetString("simpleHtml", "apples")

                    var value1 = mutableDocument.GetValue(dictonaryID);
                    var text2 = mutableDocument.GetString(dictonaryID);

                    mutableDocument.SetString(dictonaryID, modified1HTML);

                    var value3 = mutableDocument.GetValue(dictonaryID);
                    var text4 = mutableDocument.GetString(dictonaryID);

                    db.Save(mutableDocument);
                }
            }

            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = HtmlString();
            webView.Source = htmlSource;
        }

        void ModifyHTML2_Clicked(object sender, System.EventArgs e)
        {

            using (var document = db.GetDocument(docID))
            {
                using (var mutableDocument = document.ToMutable())
                {
                    //mutableDocument.SetString("simpleHtml", "apples")

                    var value1 = mutableDocument.GetValue(dictonaryID);
                    var text2 = mutableDocument.GetString(dictonaryID);

                    mutableDocument.SetString(dictonaryID, modified2HTML);

                    var value3 = mutableDocument.GetValue(dictonaryID);
                    var text4 = mutableDocument.GetString(dictonaryID);

                    db.Save(mutableDocument);
                }
            }

            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = HtmlString();
            webView.Source = htmlSource;
        }

        private Replicator PushDatabase(string username, string password, Database db)
        {
            if (String.IsNullOrWhiteSpace(username) || String.IsNullOrWhiteSpace(password))
            {
                throw new InvalidOperationException("User credentials not provided");
            }

            //if  ip changes
            SyncUrl = new Uri(txtIP.Text);
            var dbUrl = new Uri(SyncUrl, DbName);
            Debug.WriteLine(
                $"PushPull Replicator:Will connect to  {SyncUrl}");

            var config = new ReplicatorConfiguration(db, new URLEndpoint(dbUrl))
            {
                ReplicatorType = ReplicatorType.Push,
                Continuous = true,
                Authenticator = new BasicAuthenticator(username, password),
                //Channels = channels
                Channels = new[] { $"channel.{username}", $"channel.all" }
                //Channels = new[] { $"channel.all" }
                //Channels = new[] { $"channel.user" }
            };

            var repl = new Replicator(config);
            repl.AddChangeListener((sender, args) =>
            {
                var s = args.Status;
                Device.BeginInvokeOnMainThread(() =>
                {
                    s = UpdateStatus(s);
                });
                Debug.WriteLine(
                    $"PushPull Replicator: {s.Progress.Completed}/{s.Progress.Total}, error {s.Error?.Message ?? "<none>"}, activity = {s.Activity}");

            });

            repl.Start();

            //UpdateHTML();

            return repl;
        }

        void Push_Clicked(object sender, System.EventArgs e)
        {
            //StartReplication("admin", "admin1", db);
            //StartReplication("joe", "pass", db);
            GetBtn_Clicked(new object(), new EventArgs());
            PushDatabase(username, password, db);
        }

        async void Pull_clickedAsync(object sender, System.EventArgs e)
        {
            PullDatabase();
            await Restore();
        }

        void Sync_Clicked(object sender, System.EventArgs e)
        {
            SyncDatabase();
        }

        private void PullDatabase()
        {
            if (String.IsNullOrWhiteSpace(username) || String.IsNullOrWhiteSpace(password))
            {
                throw new InvalidOperationException("User credentials not provided");
            }

            SyncUrl = new Uri(txtIP.Text);
            var dbUrl = new Uri(SyncUrl, DbName);
            Debug.WriteLine(
                $"Pull Replicator:Will connect to  {SyncUrl}");

            var config = new ReplicatorConfiguration(db, new URLEndpoint(dbUrl))
            {
                ReplicatorType = ReplicatorType.Pull,
                Continuous = true,
                Authenticator = new BasicAuthenticator(username, password),
                //Channels = new[] { $"channel.demo" }
                //Channels = new[] { $"channel.user" }
                //Channels = new[] { $"channel.all" }
                Channels = new[] { $"channel.{username}", $"channel.all" }

                //Channels = channels
            };

            var repl = new Replicator(config);
            repl.AddChangeListener((sender, args) =>
            {
                //await Restore();

                var s = args.Status;
                Device.BeginInvokeOnMainThread(() =>
                {
                    s = UpdateStatus(s);

                });
                Debug.WriteLine(
                    $"Pull Replicator: {s.Progress.Completed}/{s.Progress.Total}, error {s.Error?.Message ?? "<none>"}, activity = {s.Activity}");

            });

            repl.Start();
            //return repl;

           //UpdateHTML();

            //FindListOfDocument();
        }

        private void SyncDatabase()
        {
            if (String.IsNullOrWhiteSpace(username) || String.IsNullOrWhiteSpace(password))
            {
                throw new InvalidOperationException("User credentials not provided");
            }

            SyncUrl = new Uri(txtIP.Text);
            var dbUrl = new Uri(SyncUrl, DbName);
            Debug.WriteLine(
                $"Pull Replicator:Will connect to  {SyncUrl}");

            var config = new ReplicatorConfiguration(db, new URLEndpoint(dbUrl))
            {
                ReplicatorType = ReplicatorType.PushAndPull,
                Continuous = true,
                Authenticator = new BasicAuthenticator(username, password),
                //Channels = new[] { $"channel.demo" }
                //Channels = new[] { $"channel.user" }
                //Channels = new[] { $"channel.all" }
                Channels = new[] { $"channel.{username}", $"channel.all" }

                //Channels = channels
            };

            var repl = new Replicator(config);
            repl.AddChangeListener((sender, args) =>
            {
                //await Restore();

                var s = args.Status;
                Device.BeginInvokeOnMainThread(() =>
                {
                    s = UpdateStatus(s);

                });
                Debug.WriteLine(
                    $"Pull Replicator: {s.Progress.Completed}/{s.Progress.Total}, error {s.Error?.Message ?? "<none>"}, activity = {s.Activity}");

            });

            repl.Start();
            //return repl;

            UpdateHTML();

            //FindListOfDocument();
        }

        private ReplicatorStatus UpdateStatus(ReplicatorStatus s)
        {
            txtSyncStatus.Text = s.Activity.ToString();
            txtProgress.Text = s.Progress.Total.ToString();
            txtError.Text = s.Error?.Message;
            return s;
        }

        void CheckDocuement_Clicked(object sender, System.EventArgs e)
        {
            FindListOfDocument();
        }

        private void FindListOfDocument()
        {
            using (var document = db.GetDocument("server2"))
            {
                txtDoc4.Text = "";
                if (document != null)
                {
                    txtDoc4.Text = "server2";
                }
            }
            using (var document = db.GetDocument("server"))
            {
                txtDoc3.Text = "";

                if (document != null)
                {
                    txtDoc3.Text = "server";
                }
            }
            using (var document = db.GetDocument("doc2"))
            {
                txtDoc2.Text = "";

                if (document != null)
                {
                    txtDoc2.Text = "doc2";
                }
            }

            using (var document = db.GetDocument(docID))
            {
                txtDoc1.Text = "";

                if (document != null)
                {
                    txtDoc1.Text = docID;
                    using (var mutableDocument = document.ToMutable())
                    {
                        //mutableDocument.SetString("simpleHtml", "apples")

                        //var value1 = mutableDocument.GetValue("click");
                        //var text2 = mutableDocument.GetString("click");

                        //mutableDocument.SetString("click", modified2HTML);

                        //var value3 = mutableDocument.GetValue("click");
                        //var text4 = mutableDocument.GetString("click");

                        //db.Save(mutableDocument);
                    }
                }
            }

        }
       
        private void CreateSecondDocument()
        {
            string id = "doc2";
            if (db != null && db.GetDocument(id) == null)
            {
                // Create a new document (i.e. a record) in the database
                
                IDictionary<string, object> dictionary = new Dictionary<string, object>();

                //dictionary.Add("simpleHtml", "<!DOCTYPE html><html><head><title> Page Title </title ></head><body><h1> Shrack For Student </h1><h2> Book Heading </h2><p> This is a sample paragraph. This is a sample paragraph.This is a sample paragraph.This is a sample paragraph.This is a sample paragraph.</p></body></html>");
                //dictionary.Add("SampleHtml", sampleHTML);
                string sampleHtml = "<!DOCTYPE html><html><head><title> Page beautiful </title></head><body><h1> Text </h1><h2> Book text </h2><p> This is a sample text.This is a sample text.This is a sample text.This is a sample text.This is a sample text.</p></body></html>";
                dictionary.Add(dictonaryID, sampleHtml);

                //if (db.GetDocument("htmlData") == null)
                if (db.GetDocument(id) == null)
                    using (var mutableDoc = new MutableDocument(id, dictionary))
                    {
                        mutableDoc.SetFloat("version", 1.0f)
                            .SetString("type", "HTML")
                            //.SetString("channels", channel1);
                            .SetString("channels", $"channel.{username}");
                        // Save it to the database
                        db.Save(mutableDoc);
                    }
            }
        }

        #region FullTextSearch
        private void CreateDatabaseIndex()
        {
            var ftsIndex = IndexBuilder.FullTextIndex(items: FullTextIndexItem.Property("SampleHTML"));

            db.CreateIndex("ContentFTSIndex", ftsIndex);

            /*db.CreateIndex("type", IndexBuilder.ValueIndex(ValueIndexItem.Expression(Expression.Property("type"))));

            db.CreateIndex("simpleHtml",
                           IndexBuilder.FullTextIndex(FullTextIndexItem.Property("simpleHtml")));*/
        }
        private static readonly IExpression TextProperty = Expression.Property("SampleHTML");
        public static readonly IExpression TypeProperty = Expression.Property("type");
        public void SearchText()
        {
            /* string textToBeSearched = "paragraph";
             var textExp = TextProperty.Like(Expression.String($"%{textToBeSearched}%"));

             using (var textSearchQuery = QueryBuilder
                .Select(SelectResult.All())
                .From(DataSource.Database(db))
                .Where(TypeProperty.EqualTo(Expression.String("HTML")).And(textExp)))            
                 {
                 var results = textSearchQuery.Execute().ToList();


                 var texts = results.Select(x => x.GetDictionary(0).ToDictionary(y => y.Key, y => y.Value) as Text).ToList() ;
                 return Task.FromResult(texts);

             }*/

            var ftsExpression = FullTextExpression.Index("ContentFTSIndex");

            using (var searchQuery = QueryBuilder.Select(SelectResult.Expression(Meta.ID),
              SelectResult.Expression(Expression.Property("SampleHTML")))
        .From(DataSource.Database(db))
        .Where(Expression.Property("type").EqualTo(Expression.String("HTML")).And(ftsExpression.Match("beauty"))))
            {
                var results = searchQuery.Execute().AllResults();
                foreach (var record in results)
                {
                    var data = record.ToList();
                }

            }

        }

        private void Search_Clicked(object sender, EventArgs e)
        {
            SearchText();
        }
        #endregion

        #region Highlight
        private async void Highlight_Clicked(object sender, EventArgs e)
        {
            await webView.EvaluateJavaScriptAsync($"highlightSelection()");
        }

        private async void GetBtn_Clicked(object sender, EventArgs e)
        {
            //persist the previous selections
            if (previousSelections != null)
            {
                foreach (var selection in previousSelections)
                {
                    storedSelection.Add(selection.ToString());
                }
            }
            await GetSelectionList();
          
            //store in couchbase
           var document= db.GetDocument(docID).ToMutable();
            
           
            document.SetValue("StoredSelection", storedSelection);
            
            db.Save(document);

            // App.Current.Properties["Highlight"] = storedSelection;
            // App.Current.MainPage = new MainPage();
            //await DisplayAlert("Alert", "Synched", "Ok");
        }

        //get the list from javascript
        private async Task GetSelectionList()
        {
            var selectionCount = Convert.ToInt32(await webView.EvaluateJavaScriptAsync($"getCount()"));
            for (var i = 0; i < selectionCount; i++)
            {
                var selectionString = await webView.EvaluateJavaScriptAsync($"getRange('" + i + "')");
                selectionString = "[" + selectionString + "]";
                //  storedSelection.SetValue(selectionString, i);
                storedSelection.Add(selectionString);
            }
        }

        private async void RestoreBtn_Clicked(object sender, EventArgs e)
        {
            await Restore();
        }

        private async Task Restore()
        {
            //store previous selection in JS and Highlight
            var document = db.GetDocument(docID).ToMutable();
            if (document.Contains("StoredSelection"))
            {
                 previousSelections = (MutableArrayObject)document.GetValue("StoredSelection");
                if (previousSelections != null) {
                    //await DisplayAlert("Restore Count", previousSelections.Count.ToString(), "Ok");
                    for(int i=0; i< previousSelections.Count;i++)
                    {
                        var selectedRange = previousSelections[i].ToString();
                        var result = await webView.EvaluateJavaScriptAsync($"highlightAgain('" + selectedRange + "')");
                    }                   
                }
                
            }
        }

        private async void ResetBtn_Clicked(object sender, EventArgs e)
        {
            if (storedSelection != null)
                storedSelection.Clear();
            var document = db.GetDocument(docID).ToMutable();
            if (document.Contains("StoredSelection"))
            {
                document.Remove("StoredSelection");
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await Restore();
        }
        #endregion
    }
}

