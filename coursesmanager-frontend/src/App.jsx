import { useState } from "react";
import "./App.css";

function App() {
  const [activeSection, setActiveSection] = useState("");
  const [data, setData] = useState([]);
  const [message, setMessage] = useState("");

  const [showForm, setShowForm] = useState(false);
  const [selectedCourseId, setSelectedCourseId] = useState(null);

  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [email, setEmail] = useState("");

  const fetchData = async (endpoint) => {
    const response = await fetch(`https://localhost:7250/api/${endpoint}`);
    const result = await response.json();
    setData(result);
    setActiveSection(endpoint);
    setMessage("");
    setShowForm(false);
  };

  const handleRegistration = async () => {
    try {
      //skapa deltagare
      const participantResponse = await fetch(
        "https://localhost:7250/api/participants",
        {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({
            firstName,
            lastName,
            email,
          }),
        }
      );

      const newParticipant = await participantResponse.json();

      //regga kurstillfälle
      await fetch("https://localhost:7250/api/registrations", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          participantId: newParticipant.id,
          courseSessionId: selectedCourseId,
        }),
      });

      setMessage("Successfully registered!");
      setShowForm(false);
      setFirstName("");
      setLastName("");
      setEmail("");
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <div className="page">
      <div className="card-wrapper">
        <div className="card" onClick={() => fetchData("courses")}>
          Courses
        </div>
        <div className="card" onClick={() => fetchData("coursesessions")}>
          CourseSessions
        </div>
        <div className="card" onClick={() => fetchData("participants")}>
          Participants
        </div>
        <div className="card" onClick={() => fetchData("teachers")}>
          Teachers
        </div>
      </div>

      {activeSection && (
        <div className="list-section">
          <ul>
            {data.map((item, index) => (
              <li key={index}>
                {Object.values(item).join(" - ")}

                {activeSection === "coursesessions" && (
                  <button
                    className="register-btn"
                    onClick={() => {
                      setSelectedCourseId(item.id);
                      setShowForm(true);
                    }}
                  >
                    Register here
                  </button>
                )}
              </li>
            ))}
          </ul>
        </div>
      )}

      {showForm && (
        <div className="form-section">
          <h3>Register to course</h3>

          <input
            type="text"
            placeholder="First name"
            value={firstName}
            onChange={(e) => setFirstName(e.target.value)}
          />

          <input
            type="text"
            placeholder="Last name"
            value={lastName}
            onChange={(e) => setLastName(e.target.value)}
          />

          <input
            type="email"
            placeholder="Email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
          />

          <button onClick={handleRegistration}>
            Submit
          </button>
        </div>
      )}

      {message && <p className="success-msg">{message}</p>}
    </div>
  );
}

export default App;