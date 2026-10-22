using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Viman.Models;


public class DuffelService
{
    private string token = "duffel_test_EvUkj78GJeLB_cXpl43aedOT9vhpSwgABXMeUYr7nd4";

    //public async Task<List<Flights>> SearchFlights(FlightsSearch search)
    //{
    //    List<Flights> flightsList = new List<Flights>();

    //    using (HttpClient client = new HttpClient())
    //    {
    //        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
    //        client.DefaultRequestHeaders.Add("Duffel-Version", "v2");

    //        var request = new DuffelOfferRequest
    //        {
    //            data = new DuffelOfferRequestData
    //            {
    //                slices = BuildSlices(search),
    //                passengers = BuildPassengers(search),
    //                cabin_class = MapCabin(search.FlightClass),
    //                return_offers = true
    //            }
    //        };

    //        var content = new StringContent(
    //            JsonConvert.SerializeObject(request),
    //            System.Text.Encoding.UTF8,
    //            "application/json"
    //        );

    //        var response = await client.PostAsync(
    //            "https://api.duffel.com/air/offer_requests",
    //            content
    //        );

    //        var json = await response.Content.ReadAsStringAsync();

    //        DuffelOfferResponse result =
    //            JsonConvert.DeserializeObject<DuffelOfferResponse>(json);

    //        if (result?.data?.offers == null)
    //            return flightsList;

    //        foreach (var offer in result.data.offers.Take(80))
    //        {
    //            Flights flight = MapOfferToFlight(offer, search);

    //            if (flight != null)
    //                flightsList.Add(flight);
    //        }
    //    }

    //    return flightsList;
    //}

    //private Flights MapOfferToFlight(DuffelOffer offer, FlightsSearch search)
    //{
    //    double totalAmt;
    //    double.TryParse(offer.total_amount, out totalAmt);

    //    double baseAmt;
    //    double.TryParse(offer.base_amount, out baseAmt);

    //    double taxAmt;
    //    double.TryParse(offer.tax_amount, out taxAmt);

    //    Flights flight = new Flights
    //    {
    //        Provider = "DUFFEL",
    //        FlightId = offer.id,
    //        SessionId = offer.id,
    //        Currency = offer.total_currency,
    //        FlightClass = search.FlightClass,
    //        TotalCost = totalAmt,
    //        Airline = new Airline
    //        {
    //            Code = offer.owner?.iata_code,
    //            Name = offer.owner?.name
    //        }
    //    };

    //    flight.Outbound = MapSegments(offer.slices[0].segments, false);

    //    if (offer.slices.Count > 1)
    //        flight.Inbound = MapSegments(offer.slices[1].segments, true);

    //    flight.OutboundList = new List<List<FlightsSegment>> { flight.Outbound };

    //    if (flight.Inbound != null)
    //        flight.InboundList = new List<List<FlightsSegment>> { flight.Inbound };

    //    flight.Stops = Math.Max(0, flight.Outbound.Count - 1);

    //    flight.TotalTime = ParseDuration(offer.slices[0].duration);

    //    flight.FlightFare = new FlightsFare
    //    {
    //        Adult = search.Adult,
    //        Child = search.Child,
    //        Infant = search.Infant,
    //        AdultFare = baseAmt,
    //        AdultTax = taxAmt
    //    };

    //    // BAGGAGE
    //    var pax = offer.passengers?.FirstOrDefault();

    //    if (pax != null)
    //    {
    //        var segPax = offer.slices[0].segments
    //            .FirstOrDefault()
    //            ?.passengers
    //            ?.FirstOrDefault(p => p.passenger_id == pax.id);

    //        if (segPax?.baggages != null)
    //        {
    //            flight.Baglimit = new Baglimit
    //            {
    //                hold_weight = segPax.baggages
    //                    .Where(x => x.type == "checked")
    //                    .Sum(x => x.quantity) + " Piece",

    //                hand_weight = segPax.baggages
    //                    .Where(x => x.type == "carry_on")
    //                    .Sum(x => x.quantity) + " Piece"
    //            };
    //        }
    //    }

    //    return flight;
    //}

    //private List<FlightsSegment> MapSegments(List<DuffelSegment> segments,bool isReturn)
    //{
    //    List<FlightsSegment> list = new List<FlightsSegment>();

    //    int totalMinutes = 0;
    //    DateTime? lastArrival = null;

    //    foreach (var seg in segments)
    //    {
    //        DateTime dep = DateTime.Parse(seg.departing_at);
    //        DateTime arr = DateTime.Parse(seg.arriving_at);

    //        if (lastArrival != null)
    //            totalMinutes += (int)(dep - lastArrival.Value).TotalMinutes;

    //        int segMin = ParseDuration(seg.duration);

    //        if (segMin == 0)
    //            segMin = (int)(arr - dep).TotalMinutes;

    //        totalMinutes += segMin;

    //        lastArrival = arr;

    //        list.Add(new FlightsSegment
    //        {
    //            SagementRef = seg.id,

    //            DepartureDate = dep,
    //            ArrivalDate = arr,

    //            Depdate1 = dep,
    //            Arrdate1 = arr,

    //            Departuretime = dep.ToString("HH:mm"),
    //            Arrivaltime = arr.ToString("HH:mm"),

    //            FromAirport = new Airport
    //            {
    //                Code = seg.origin?.iata_code,
    //                Name = seg.origin?.name
    //            },

    //            ToAirport = new Airport
    //            {
    //                Code = seg.destination?.iata_code,
    //                Name = seg.destination?.name
    //            },

    //            Airline = new Airline
    //            {
    //                Code = seg.marketing_carrier?.iata_code,
    //                Name = seg.marketing_carrier?.name
    //            },

    //            OperatingAirline = new Airline
    //            {
    //                Code = seg.operating_carrier?.iata_code,
    //                Name = seg.operating_carrier?.name
    //            },

    //            FlightNo = seg.operating_carrier_flight_number,
    //            EquipmentType = seg.aircraft?.name,

    //            FromTerminal = seg.origin_terminal,
    //            ToTerminal = seg.destination_terminal,

    //            ElapsedTime = segMin.ToString(),
    //            TotalTime = totalMinutes.ToString(),

    //            CabinClass = seg.passengers?
    //                .FirstOrDefault()?.cabin_class,

    //            IsReturn = isReturn
    //        });
    //    }

    //    return list;
    //}

    //private List<DuffelSlice> BuildSlices(FlightsSearch search)
    //{
    //    List<DuffelSlice> slices = new List<DuffelSlice>();

    //    slices.Add(new DuffelSlice
    //    {
    //        origin = search.From.Code,
    //        destination = search.To.Code,
    //        departure_date = search.DepDate.ToString("yyyy-MM-dd")
    //    });

    //    if (search.FlightWay == FlightWay.RoundTrip)
    //    {
    //        slices.Add(new DuffelSlice
    //        {
    //            origin = search.To.Code,
    //            destination = search.From.Code,
    //            departure_date = search.RetDate.ToString("yyyy-MM-dd")
    //        });
    //    }

    //    return slices;
    //}

    //private List<DuffelPassenger> BuildPassengers(FlightsSearch search)
    //{
    //    List<DuffelPassenger> list = new List<DuffelPassenger>();

    //    for (int i = 0; i < search.Adult; i++)
    //        list.Add(new DuffelPassenger { type = "adult" });

    //    for (int i = 0; i < search.Child; i++)
    //        list.Add(new DuffelPassenger { type = "child", age = 10 });

    //    for (int i = 0; i < search.Infant; i++)
    //        list.Add(new DuffelPassenger { type = "infant_without_seat", age = 1 });

    //    return list;
    //}

    //private string MapCabin(FlightClass cabin)
    //{
    //    switch (cabin)
    //    {
    //        case FlightClass.Business: return "business";
    //        case FlightClass.First: return "first";
    //        case FlightClass.EconomyPremium: return "premium_economy";
    //        default: return "economy";
    //    }
    //}

    //private int ParseDuration(string duration)
    //{
    //    try
    //    {
    //        var ts = System.Xml.XmlConvert.ToTimeSpan(duration);
    //        return (int)ts.TotalMinutes;
    //    }
    //    catch
    //    {
    //        return 0;
    //    }
    //}
}