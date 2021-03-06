﻿using System.Collections.Generic;
using System;

namespace Composite
{
    public interface RoomB
    {
        string Schedule(int level);
        void AddEvent(string eventDescription);
        void AddRoom(Room room);
        void RemoveRoom(Room room);
    }

    public class ClassRoomB : RoomB
    {
        public string Name { get; }

        private List<string> _events = new List<string>();

        public void AddEvent(string eventDescription)
        {
            _events.Add(eventDescription);
        }

        public string Schedule(int level)
        {
            var schedule = "";
            for (int lvl = 0; lvl < level; lvl++)
            {
                schedule += "\t";
            }
            schedule += $"{Name}: ";

            foreach (var e in _events)
            {
                schedule += $"{e}, ";
            }
            schedule = schedule.Substring(0, schedule.Length - 2);

            return schedule;
        }

        public ClassRoomB(string name)
        {
            Name = name;
        }

        public void AddRoom(Room room)
        {
            throw new InvalidOperationException();
        }

        public void RemoveRoom(Room room)
        {
            throw new InvalidOperationException();
        }
    }

    public class RoomGroupB : RoomB
    {
        public string Name { get; }

        private List<Room> _rooms = new List<Room>();

        public void AddEvent(string eventDescription)
        {
            foreach (var room in _rooms)
            {
                room.AddEvent(eventDescription);
            }
        }

        public string Schedule(int level)
        {
            var schedule = "";
            for (int lvl = 0; lvl < level; lvl++)
            {
                schedule += "\t";
            }
            schedule += $"{Name}:\n";

            foreach (var room in _rooms)
            {
                schedule += $"{room.Schedule(level + 1)}\n";
            }
            schedule = schedule = schedule.Substring(0, schedule.Length - 1);

            return schedule;
        }

        public void AddRoom(Room room)
        {
            _rooms.Add(room);
        }

        public void RemoveRoom(Room room)
        {
            _rooms.Remove(room);
        }

        public RoomGroupB(string name)
        {
            Name = name;
        }
    }
}
