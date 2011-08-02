﻿using System;
using FakeItEasy;
using Machine.Specifications;
using Paramore.Domain.Meetings;
using Paramore.Infrastructure.Domain;

namespace Paramore.Tests.domain.Meetings
{
    [Subject("Ensure that we preserve invariants when building with a factory")]
    public class When_we_schedule_a_meeting_there_should_be_tickets_over_capacity
    {
        static Scheduler scheduler;
        static Capacity capacity;
        static IBookingPolicy bookingPolicy;

        Establish context = () =>
                                {
                                    capacity = new Capacity(10);
                                    bookingPolicy = A.Fake<IBookingPolicy>();
                                    var tickets = new Tickets(capacity);
                                    A.CallTo(() => bookingPolicy.AllocateTickets(capacity)).Returns(tickets);

                                    scheduler = new Scheduler(bookingPolicy);

                                };

        Because of = () => scheduler.Schedule(new Id(Guid.NewGuid()), new MeetingDate(DateTime.Today), new Id(Guid.NewGuid()), new Id(Guid.NewGuid()), capacity);

        It should_call_the_booking_policy_to_allocate_tickets = () => A.CallTo(() => bookingPolicy.AllocateTickets(capacity)).MustHaveHappened();

    }
}