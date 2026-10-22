using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Viman.Models;
using static Viman.Models.Common;


namespace Viman.Controllers
{
    public class HomeController : Controller
    {


        [HttpPost]
        public ActionResult SearchTrain(TrainSearchModel model)
        {
            string connStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            // Flight Type
            string flighttrip = model.flight_way == 1 ? "One way" : "Round Trip";

            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = @"INSERT INTO FlightSearch
     (FlightWay, FromCity, ToCity, FromDate, ToDate, Name, Email, Phone, Adult, Child, Infant, Source, Enqtype)
     VALUES
     (@FlightWay, @FromCity, @ToCity, @FromDate, @ToDate, @Name, @Email, @Phone, @Adult, @Child, @Infant, @Source, @Enqtype)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@FlightWay", flighttrip);
                cmd.Parameters.AddWithValue("@FromCity", model.flight_fromtrain);
                cmd.Parameters.AddWithValue("@ToCity", model.flight_totrain);
                cmd.Parameters.AddWithValue("@FromDate", model.flight_from_date);
                cmd.Parameters.AddWithValue("@ToDate", model.flight_to_date);
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@Email", model.Email);
                cmd.Parameters.AddWithValue("@Phone", model.Phoneno);
                cmd.Parameters.AddWithValue("@Adult", model.flight_adult);
                cmd.Parameters.AddWithValue("@Child", model.flight_child);
                cmd.Parameters.AddWithValue("@Infant", model.flight_infant);

                cmd.Parameters.AddWithValue("@Source", "fareschoices");
                cmd.Parameters.AddWithValue("@Enqtype", "Amtrak");

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }




            return RedirectToAction("https://www.fareschoices.com/thankYou");
        }


        [Route("~/")]
        public ActionResult Index()
        {

            return View();
        }

        [Route("about-us")]
        public ActionResult aboutus()
        {

            return View();
        }

        [Route("american-cruise-lines")]
        public ActionResult americancruiselines()
        {

            return View();
        }

        [Route("bahamas-paradise-cruise-line")]
        public ActionResult bahamasparadisecruiseline()
        {

            return View();
        }

        [Route("blog")]
        public ActionResult blog()
        {

            return View();
        }

        [Route("carnival-cruise-line")]
        public ActionResult carnivalcruiseline()
        {

            return View();
        }

        [Route("celebrity-cruise-line")]
        public ActionResult celebritycruiseline()
        {

            return View();
        }

        [Route("celestyal-cruises")]
        public ActionResult celestyalcruises()
        {

            return View();
        }

        [Route("contact")]
        public ActionResult contact()
        {

            return View();
        }

        [Route("costa-cruise-line")]
        public ActionResult costacruiseline()
        {

            return View();
        }

        [Route("cruise")]
        public ActionResult cruise()
        {

            return View();
        }

        [Route("cruise-to-alaska")]
        public ActionResult cruisetoalaska()
        {

            return View();
        }


        [Route("cruise-to-antarctica")]
        public ActionResult cruisetoantarctica()
        {

            return View();
        }

        [Route("cruise-to-aruba")]
        public ActionResult cruisetoaruba()
        {

            return View();
        }

        [Route("cruise-to-australia")]
        public ActionResult cruisetoaustralia()
        {

            return View();
        }

        [Route("cruise-to-bahamas")]
        public ActionResult cruisetobahamas()
        {

            return View();
        }

        [Route("cruise-to-barbados")]
        public ActionResult cruisetobarbados()
        {

            return View();
        }

        [Route("cruise-to-belize")]
        public ActionResult cruisetobelize()
        {

            return View();
        }

        [Route("cruise-to-bermuda")]
        public ActionResult cruisetobermuda()
        {

            return View();
        }

        [Route("cruise-to-bora-bora")]
        public ActionResult cruisetoborabora()
        {

            return View();
        }

        [Route("cruise-to-brazil")]
        public ActionResult cruisetobrazil()
        {

            return View();
        }

        [Route("cruise-to-cabo")]
        public ActionResult cruisetocabo()
        {

            return View();
        }

        [Route("cruise-to-canada")]
        public ActionResult cruisetocanada()
        {

            return View();
        }

        [Route("cruise-to-cancun")]
        public ActionResult cruisetocancun()
        {

            return View();
        }

        [Route("cruise-to-caribbean")]
        public ActionResult cruisetocaribbean()
        {

            return View();
        }

        [Route("cruise-to-costa-rica")]
        public ActionResult cruisetocostarica()
        {

            return View();
        }

        [Route("cruise-to-cozumel")]
        public ActionResult cruisetocozumel()
        {

            return View();
        }

        [Route("cruise-to-cuba")]
        public ActionResult cruisetocuba()
        {

            return View();
        }

        [Route("cruise-to-dominican-republic")]
        public ActionResult cruisetodominicanrepublic()
        {

            return View();
        }

        [Route("cruise-to-ensenada")]
        public ActionResult cruisetoensenada()
        {

            return View();
        }

        [Route("cruise-to-europe")]
        public ActionResult cruisetoeurope()
        {

            return View();
        }

        [Route("cruise-to-galapagos-islands")]
        public ActionResult cruisetogalapagosislands()
        {

            return View();
        }

        [Route("cruise-to-greece")]
        public ActionResult cruisetogreece()
        {

            return View();
        }

        [Route("cruise-to-greenland")]
        public ActionResult cruisetogreenland()
        {

            return View();
        }

        [Route("cruise-to-hawaii")]
        public ActionResult cruisetohawaii()
        {

            return View();
        }

        [Route("cruise-to-iceland")]
        public ActionResult cruisetoiceland()
        {

            return View();
        }

        [Route("cruise-to-ireland")]
        public ActionResult cruisetoireland()
        {

            return View();
        }

       

        [Route("cruise-to-italy")]
        public ActionResult cruisetoitaly()
        {

            return View();
        }

        [Route("cruise-to-jamaica")]
        public ActionResult cruisetojamaica()
        {

            return View();
        }

        [Route("cruise-to-japan")]
        public ActionResult cruisetojapan()
        {

            return View();
        }

        [Route("cruise-to-key-west")]
        public ActionResult cruisetokeywest()
        {

            return View();
        }

        [Route("cruise-to-los-cabos")]
        public ActionResult cruisetoloscabos()
        {

            return View();
        }

        [Route("cruise-to-mexico")]
        public ActionResult cruisetomexico()
        {

            return View();
        }

        [Route("cruise-to-new-england")]
        public ActionResult cruisetonewengland()
        {

            return View();
        }

       

        [Route("cruise-to-new-jersey")]
        public ActionResult cruisetonewjersey()
        {

            return View();
        }

        [Route("cruise-to-norway")]
        public ActionResult cruisetonorway()
        {

            return View();
        }

        [Route("cruise-to-nova-scotia")]
        public ActionResult cruisetonovascotia()
        {

            return View();
        }

        [Route("cruise-to-nowhere")]
        public ActionResult cruisetonowhere()
        {

            return View();
        }

        [Route("cruise-to-panama-canal")]
        public ActionResult cruisetopanamacanal()
        {

            return View();
        }

        [Route("cruise-to-puerto-rico")]
        public ActionResult cruisetopuertorico()
        {

            return View();
        }

        [Route("cruise-to-south-america")]
        public ActionResult cruisetosouthamerica()
        {

            return View();
        }

        [Route("cruise-to-spain")]
        public ActionResult cruisetospain()
        {

            return View();
        }

        [Route("cruise-to-st-lucia")]
        public ActionResult cruisetostlucia()
        {

            return View();
        }

        [Route("cruise-to-the-us-virgin-islands")]
        public ActionResult cruisetotheusvirginislands()
        {

            return View();
        }

        [Route("cunard-cruise-line")]
        public ActionResult cunardcruiseline()
        {

            return View();
        }

        [Route("disney-cruise-line")]
        public ActionResult disneycruiseline()
        {

            return View();
        }

        [Route("flights-to-akron")]
        public ActionResult flightstoakron()
        {

            return View();
        }

        [Route("flights-to-alabama")]
        public ActionResult flightstoalabama()
        {

            return View();
        }

        [Route("flights-to-alaska")]
        public ActionResult flightstoalaska()
        {

            return View();
        }

        [Route("flights-to-albuquerque")]
        public ActionResult flightstoalbuquerque()
        {

            return View();
        }

        [Route("flights-to-allen")]
        public ActionResult flightstoallen()
        {

            return View();
        }

        [Route("flights-to-amarillo")]
        public ActionResult flightstoamarillo()
        {

            return View();
        }

        [Route("flights-to-anaheim")]
        public ActionResult flightstoanaheim()
        {

            return View();
        }

        [Route("flights-to-anchorage")]
        public ActionResult flightstoanchorage()
        {

            return View();
        }

        [Route("flights-to-arizona")]
        public ActionResult flightstoarizona()
        {

            return View();
        }
        [Route("flights-to-arkansas")]
        public ActionResult flightstoarkansas()
        {

            return View();
        }

        [Route("flights-to-arlington")]
        public ActionResult flightstoarlington()
        {

            return View();
        }

        [Route("flights-to-atlanta")]
        public ActionResult flightstoatlanta()
        {

            return View();
        }

        [Route("flights-to-augusta")]
        public ActionResult flightstoaugusta()
        {

            return View();
        }

        [Route("flights-to-aurora")]
        public ActionResult flightstoaurora()
        {

            return View();
        }

        [Route("flights-to-austin")]
        public ActionResult flightstoaustin()
        {

            return View();
        }

        [Route("flights-to-calabasas")]
        public ActionResult flightstocalabasas()
        {

            return View();
        }

        [Route("flights-to-chicago")]
        public ActionResult flightstochicago()
        {

            return View();
        }

        [Route("flights-to-fremont")]
        public ActionResult flightstofremont()
        {

            return View();
        }

        [Route("flights-to-miami")]
        public ActionResult flightstomiami()
        {

            return View();
        }

        [Route("holland-america-cruises")]
        public ActionResult hollandamericacruises()
        {

            return View();
        }

        [Route("msc-cruise-line")]
        public ActionResult msccruiseline()
        {

            return View();
        }

        [Route("norwegian-cruise-line")]
        public ActionResult norwegiancruiseline()
        {

            return View();
        }

        [Route("oceania-cruises")]
        public ActionResult oceaniacruises()
        {

            return View();
        }

        [Route("paul-gauguin-cruises")]
        public ActionResult paulgauguincruises()
        {

            return View();
        }

        [Route("po-cruises-lines")]
        public ActionResult pocruiseslines()
        {

            return View();
        }

        [Route("ponant-cruises")]
        public ActionResult ponantcruises()
        {

            return View();
        }

        [Route("princess-cruises")]
        public ActionResult princesscruises()
        {

            return View();
        }

        [Route("privacy-policy")]
        public ActionResult privacypolicy()
        {

            return View();
        }

        [Route("quark-expeditions-cruises")]
        public ActionResult quarkexpeditionscruises()
        {

            return View();
        }

        [Route("regent-seven-seas-cruise-line")]
        public ActionResult regentsevenseascruiseline()
        {

            return View();
        }

        [Route("royal-caribbean-cruises")]
        public ActionResult royalcaribbeancruises()
        {

            return View();
        }

        [Route("seabourn-cruise-line")]
        public ActionResult seabourncruiseline()
        {

            return View();
        }


        [Route("silversea-cruises")]
        public ActionResult silverseacruises()
        {

            return View();
        }


        [Route("terms-and-conditions")]
        public ActionResult termsandconditions()
        {

            return View();
        }

        [Route("thankyou")]
        public ActionResult thankyou()
        {

            return View();
        }

        [Route("train")]
        public ActionResult train()
        {

            return View();
        }

        [Route("train-from-alexandria-to-fredericksburg")]
        public ActionResult trainfromalexandriatofredericksburg()
        {

            return View();
        }

        [Route("train-from-alexandria-to-new-york")]
        public ActionResult trainfromalexandriatonewyork()
        {

            return View();
        }

        [Route("train-from-alexandria-to-norfolk")]
        public ActionResult trainfromalexandriatonorfolk()
        {

            return View();
        }

        [Route("train-from-alexandria-to-philadelphia")]
        public ActionResult trainfromalexandriatophiladelphia()
        {

            return View();
        }

        [Route("train-from-alexandria-to-raleigh")]
        public ActionResult trainfromalexandriatoraleigh()
        {

            return View();
        }

        [Route("train-from-alexandria-to-richmond")]
        public ActionResult trainfromalexandriatorichmond()
        {

            return View();
        }

        [Route("train-from-alexandria-to-roanoke")]
        public ActionResult trainfromalexandriatoroanoke()
        {

            return View();
        }

        [Route("train-from-alexandria-to-williamsburg")]
        public ActionResult trainfromalexandriatowilliamsburg()
        {

            return View();
        }

        [Route("train-from-anchorage-to-fairbanks")]
        public ActionResult trainfromanchoragetofairbanks()
        {

            return View();
        }

        [Route("train-from-baltimore-to-boston")]
        public ActionResult trainfrombaltimoretoboston()
        {

            return View();
        }

        [Route("train-from-baltimore-to-iselin")]
        public ActionResult trainfrombaltimoretoiselin()
        {

            return View();
        }

        [Route("train-from-baltimore-to-newark")]
        public ActionResult trainfrombaltimoretonewark()
        {

            return View();
        }

        [Route("train-from-baltimore-to-new-haven")]
        public ActionResult trainfrombaltimoretonewhaven()
        {

            return View();
        }

        [Route("train-from-baltimore-to-new-york")]
        public ActionResult trainfrombaltimoretonewyork()
        {

            return View();
        }

        [Route("train-from-baltimore-to-norfolk")]
        public ActionResult trainfrombaltimoretonorfolk()
        {

            return View();
        }

        [Route("train-from-baltimore-to-orlando")]
        public ActionResult trainfrombaltimoretoorlando()
        {

            return View();
        }

        [Route("train-from-baltimore-to-philadelphia")]
        public ActionResult trainfrombaltimoretophiladelphia()
        {

            return View();
        }

        [Route("train-from-baltimore-to-trenton")]
        public ActionResult trainfrombaltimoretotrenton()
        {

            return View();
        }

        [Route("train-from-baltimore-to-washington-dc")]
        public ActionResult trainfrombaltimoretowashingtondc()
        {

            return View();
        }

        [Route("train-from-baltimore-to-wilmington")]
        public ActionResult trainfrombaltimoretowilmington()
        {

            return View();
        }

        [Route("train-from-boston-to-bridgeport")]
        public ActionResult trainfrombostontobridgeport()
        {

            return View();
        }

        [Route("train-from-boston-to-chicago")]
        public ActionResult trainfrombostontochicago()
        {

            return View();
        }

        [Route("train-from-boston-to-new-york")]
        public ActionResult trainfrombostontonewyork()
        {

            return View();
        }

        [Route("train-from-boston-to-philadelphia")]
        public ActionResult trainfrombostontophiladelphia()
        {

            return View();
        }

        [Route("train-from-boston-to-providence")]
        public ActionResult trainfrombostontoprovidence()
        {

            return View();
        }

        [Route("train-from-boston-to-washington")]
        public ActionResult trainfrombostontowashington()
        {

            return View();
        }

        [Route("train-from-buffalo-to-new-york")]
        public ActionResult trainfrombuffalotonewyork()
        {

            return View();
        }


        [Route("train-from-charlottesville-to-alexandria")]
        public ActionResult trainfromcharlottesvilletoalexandria()
        {

            return View();
        }


        [Route("train-from-charlottesville-to-atlanta")]
        public ActionResult trainfromcharlottesvilletoatlanta()
        {

            return View();
        }

        [Route("train-from-charlottesville-to-baltimore")]
        public ActionResult trainfromcharlottesvilletobaltimore()
        {

            return View();
        }

        [Route("train-from-charlottesville-to-boston")]
        public ActionResult trainfromcharlottesvilletoboston()
        {

            return View();
        }

        [Route("train-from-charlottesville-to-burke")]
        public ActionResult trainfromcharlottesvilletoburke()
        {

            return View();
        }

        [Route("train-from-charlottesville-to-newark")]
        public ActionResult trainfromcharlottesvilletonewark()
        {

            return View();
        }

        [Route("train-from-charlottesville-to-philadelphia")]
        public ActionResult trainfromcharlottesvilletophiladelphia()
        {

            return View();
        }

        [Route("train-from-charlottesville-to-washington-dc")]
        public ActionResult trainfromcharlottesvilletowashingtondc()
        {

            return View();
        }

        [Route("train-from-charlotte-to-greensboro")]
        public ActionResult trainfromcharlottetogreensboro()
        {

            return View();
        }

        [Route("train-from-charlotte-to-miami")]
        public ActionResult trainfromcharlottetomiami()
        {

            return View();
        }

        [Route("train-from-charlotte-to-philadelphia")]
        public ActionResult trainfromcharlottetophiladelphia()
        {

            return View();
        }

        [Route("train-from-charlotte-to-raleigh")]
        public ActionResult trainfromcharlottetoraleigh()
        {

            return View();
        }

        [Route("train-from-charlotte-to-richmond")]
        public ActionResult trainfromcharlottetorichmond()
        {

            return View();
        }

        [Route("train-from-charlotte-to-washington-dc")]
        public ActionResult trainfromcharlottetowashingtondc()
        {

            return View();
        }

        [Route("train-from-chicago-to-ann-arbor")]
        public ActionResult trainfromchicagotoannarbor()
        {

            return View();
        }

        [Route("train-from-chicago-to-bloomington")]
        public ActionResult trainfromchicagotobloomington()
        {

            return View();
        }

        [Route("train-from-chicago-to-indianapolis")]
        public ActionResult trainfromchicagotoindianapolis()
        {

            return View();
        }

        [Route("train-from-chicago-to-minneapolis")]
        public ActionResult trainfromchicagotominneapolis()
        {

            return View();
        }

        [Route("train-from-chicago-to-new-york")]
        public ActionResult trainfromchicagotonewyork()
        {

            return View();
        }

        [Route("train-from-chicago-to-san-francisco")]
        public ActionResult trainfromchicagotosanfrancisco()
        {

            return View();
        }

        [Route("train-from-chicago-to-seattle")]
        public ActionResult trainfromchicagotoseattle()
        {

            return View();
        }

        [Route("train-from-chicago-to-st-louis")]
        public ActionResult trainfromchicagotostlouis()
        {

            return View();
        }

        [Route("train-from-detroit-to-chicago")]
        public ActionResult trainfromdetroittochicago()
        {

            return View();
        }


        [Route("train-from-hartford-to-new-york")]
        public ActionResult trainfromhartfordtonewyork()
        {

            return View();
        }

        [Route("train-from-las-vegas-to-los-angeles")]
        public ActionResult trainfromlasvegastolosangeles()
        {

            return View();
        }

        [Route("train-from-los-angeles-to-san-diego")]
        public ActionResult trainfromlosangelestosandiego()
        {

            return View();
        }


        [Route("train-from-minneapolis-to-chicago")]
        public ActionResult trainfromminneapolistochicago()
        {

            return View();
        }


        [Route("train-from-new-haven-to-boston")]
        public ActionResult trainfromnewhaventoboston()
        {

            return View();
        }

        [Route("train-from-new-york-to-albany")]
        public ActionResult trainfromnewyorktoalbany()
        {

            return View();
        }

        [Route("train-from-new-york-to-baltimore")]
        public ActionResult trainfromnewyorktobaltimore()
        {

            return View();
        }


        [Route("train-from-new-york-to-boston")]
        public ActionResult trainfromnewyorktoboston()
        {

            return View();
        }


        [Route("train-from-new-york-to-chicago")]
        public ActionResult trainfromnewyorktochicago()
        {

            return View();
        }

        [Route("train-from-new-york-to-new-haven")]
        public ActionResult trainfromnewyorktonewhaven()
        {

            return View();
        }

        [Route("train-from-new-york-to-philadelphia")]
        public ActionResult trainfromnewyorktophiladelphia()
        {

            return View();
        }


        [Route("train-from-new-york-to-pittsburgh")]
        public ActionResult trainfromnewyorktopittsburgh()
        {

            return View();
        }


        [Route("train-from-new-york-to-providence")]
        public ActionResult trainfromnewyorktoprovidence()
        {

            return View();
        }


        [Route("train-from-orlando-to-miami")]
        public ActionResult trainfromorlandotomiami()
        {

            return View();
        }


        [Route("train-from-philadelphia-to-atlantic-city")]
        public ActionResult trainfromphiladelphiatoatlanticcity()
        {

            return View();
        }


        [Route("train-from-philadelphia-to-boston")]
        public ActionResult trainfromphiladelphiatoboston()
        {

            return View();
        }


        [Route("train-from-philadelphia-to-washington")]
        public ActionResult trainfromphiladelphiatowashington()
        {

            return View();
        }

        [Route("train-from-portland-to-boston")]
        public ActionResult trainfromportlandtoboston()
        {

            return View();
        }

        [Route("train-from-portland-to-seattle")]
        public ActionResult trainfromportlandtoseattle()
        {

            return View();
        }

        [Route("train-from-san-diego-to-los-angeles")]
        public ActionResult trainfromsandiegotolosangeles()
        {

            return View();
        }


        [Route("train-from-seattle-to-leavenworth")]
        public ActionResult trainfromseattletoleavenworth()
        {

            return View();
        }

        [Route("train-from-st-louis-to-chicago")]
        public ActionResult trainfromstlouistochicago()
        {

            return View();
        }

        [Route("train-from-tampa-to-miami")]
        public ActionResult trainfromtampatomiami()
        {

            return View();
        }

        [Route("train-from-tampa-to-orlando")]
        public ActionResult trainfromtampatoorlando()
        {

            return View();
        }

        [Route("train-from-washington-dc-to-boston")]
        public ActionResult trainfromwashingtondctoboston()
        {

            return View();
        }

        [Route("train-from-washington-to-philadelphia")]
        public ActionResult trainfromwashingtontophiladelphia()
        {

            return View();
        }


        [Route("train-tickets")]
        public ActionResult traintickets()
        {

            return View();
        }

        [Route("train-to-alaska")]
        public ActionResult traintoalaska()
        {

            return View();
        }

        [Route("train-to-atlanta")]
        public ActionResult traintoatlanta()
        {

            return View();
        }

        [Route("train-to-baltimore")]
        public ActionResult traintobaltimore()
        {

            return View();
        }

        [Route("train-to-boston")]
        public ActionResult traintoboston()
        {

            return View();
        }


        [Route("train-to-california")]
        public ActionResult traintocalifornia()
        {

            return View();
        }

        [Route("train-to-canada")]
        public ActionResult traintocanada()
        {

            return View();
        }


        [Route("train-to-chicago")]
        public ActionResult traintochicago()
        {

            return View();
        }

        [Route("train-to-colorado")]
        public ActionResult traintocolorado()
        {

            return View();
        }

        [Route("train-to-dallas")]
        public ActionResult traintodallas()
        {

            return View();
        }

        [Route("train-to-florida")]
        public ActionResult traintoflorida()
        {

            return View();
        }

        [Route("train-to-grand-canyon")]
        public ActionResult traintograndcanyon()
        {

            return View();
        }

        [Route("train-to-las-vegas")]
        public ActionResult traintolasvegas()
        {

            return View();
        }

        [Route("train-to-los-angeles")]
        public ActionResult traintolosangeles()
        {

            return View();
        }

        [Route("train-to-miami")]
        public ActionResult traintomiami()
        {

            return View();
        }

        [Route("train-to-montreal")]
        public ActionResult traintomontreal()
        {

            return View();
        }

        [Route("train-to-nashville")]
        public ActionResult traintonashville()
        {

            return View();
        }

        [Route("train-to-newark")]
        public ActionResult traintonewark()
        {

            return View();
        }

        [Route("train-to-new-jersey")]
        public ActionResult traintonewjersey()
        {

            return View();
        }

        [Route("train-to-new-orleans")]
        public ActionResult traintoneworleans()
        {

            return View();
        }

        [Route("train-to-new-york")]
        public ActionResult traintonewyork()
        {

            return View();
        }

        [Route("train-to-north-carolina")]
        public ActionResult traintonorthcarolina()
        {

            return View();
        }

        [Route("train-to-oregon")]
        public ActionResult traintooregon()
        {

            return View();
        }

        [Route("train-to-orlando")]
        public ActionResult traintoorlando()
        {

            return View();
        }

        [Route("train-to-philadelphia")]
        public ActionResult traintophiladelphia()
        {

            return View();
        }

        [Route("train-to-philly")]
        public ActionResult traintophilly()
        {

            return View();
        }

        [Route("train-to-san-antonio")]
        public ActionResult traintosanantonio()
        {

            return View();
        }

        [Route("train-to-san-diego")]
        public ActionResult traintosandiego()
        {

            return View();
        }

        [Route("train-to-san-francisco")]
        public ActionResult traintosanfrancisco()
        {

            return View();
        }

        [Route("train-to-seattle")]
        public ActionResult traintoseattle()
        {

            return View();
        }

        [Route("train-to-texas")]
        public ActionResult traintotexas()
        {

            return View();
        }

        [Route("train-to-toronto")]
        public ActionResult traintotoronto()
        {

            return View();
        }

        [Route("train-to-washington-dc")]
        public ActionResult traintowashingtondc()
        {

            return View();
        }

        [Route("viking-ocean-cruises")]
        public ActionResult vikingoceancruises()
        {

            return View();
        }

        [Route("virgin-voyages-cruises")]
        public ActionResult virginvoyagescruises()
        {

            return View();
        }

        [Route("windstar-cruises")]
        public ActionResult windstarcruises()
        {

            return View();
        }

       







        [Route("train-from-albany-to-new-york")]
        public ActionResult trainfromalbanytonewyork()
        {

            return View();
        }




    }

}