using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace AP_Project
{
    internal class DatabaseHelper
    {
        private static string constr =
            "server = 127.0.0.1; port=3306;database=event_management_db;uid=root;pwd=root;";
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(constr);
        }

        public static DataRow GetUserByEmail(string email)
        {
            using (MySqlConnection conn = GetConnection())
            {
                string query = @"
                    SELECT staff_id, name, email, password, role
                    FROM staff_users
                    WHERE email = @email
                    LIMIT 1";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@email", email);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                        return dt.Rows[0];

                    return null;
                }
            }
        }
        public static DataTable GetAllEvents()
        {
            using (MySqlConnection conn = GetConnection())
            {
                string query = "SELECT * FROM events";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public static DataTable GetAllParticipants()
        {
            using (MySqlConnection conn = GetConnection())
            {
                string query = "SELECT * FROM participants";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
        public static bool InsertAttendanceLog(int eventId, int participantId, int scannedBy)
        {
            using (MySqlConnection conn = GetConnection())
            {
                string query = @"
                    INSERT INTO attendance_logs
                    (event_id, participant_id, scanned_by)
                    VALUES
                    (@eventId, @participantId, @scannedBy)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@eventId", eventId);
                    cmd.Parameters.AddWithValue("@participantId", participantId);
                    cmd.Parameters.AddWithValue("@scannedBy", scannedBy);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool AlreadyScanned(int eventId, int participantId)
        {
            using (MySqlConnection conn = GetConnection())
            {
                string query = @"
                    SELECT COUNT(*)
                    FROM attendance_logs
                    WHERE event_id = @eventId
                    AND participant_id = @participantId";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@eventId", eventId);
                    cmd.Parameters.AddWithValue("@participantId", participantId);

                    conn.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }
    }
}