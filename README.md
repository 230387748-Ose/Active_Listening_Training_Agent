# Active Listening Training Agent
An Augmented Reality system developed using Unity and HoloLens 2, designed to enhance communication skills by providing real-time feedback on active listening behaviors, particularly in scenarios involving interactions with individuals of diverse affective states.

![Demo](path-to-your-gif-or-image.gif)

[![Unity](https://img.shields.io/badge/Unity-v2024-blue)](https://unity.com)
[![License](https://img.shields.io/badge/license-MIT-green)](LICENSE)

## Table of Contents
1. [Features](#features)
2. [Technology Stack](#technology-stack)
3. [Installation and Usage](#installation-and-usage)
4. [System Design](#system-design)
5. [Data Collection and Analysis](#data-collection-and-analysis)
6. [Results](#results)
7. [Future Enhancements](#future-enhancements)
8. [Acknowledgments](#acknowledgments)


## Features
- Augmented Reality system developed for Microsoft HoloLens 2.
- Real-time tracking of:
  - Eye movements (focus and attention measurement).
  - Head orientation (engagement analysis).
  - Voice detection (interruption analysis).
- Data logging at 20ms intervals for precise analysis.
- Interactive questionnaires for user experience evaluation.


## Technology Stack
- **Unity**: Game engine for AR application development.
- **Microsoft HoloLens 2**: AR hardware.
- **SALSA LipSync Suite**: Lip synchronization.
- **C#**: Programming language for scripting.
- **Play.ht**: AI-driven text-to-speech tool.
- **GitHub**: Version control and project management.


## Installation and Usage
1. Clone the repository:
   ```bash
   git clone https://github.com/username/active-listening-agent.git
2. Open the project in Unity (version 2020 or later).
3. Deploy the project to a HoloLens 2 device using the MRTK setup.
4. Run the application and follow the on-screen instructions.

---
## System Design
![image](https://github.com/user-attachments/assets/e7c0c80c-259c-4a35-84eb-86b6e67af7ec)

## Data Collection and Analysis
#### Data Collection:
Data collection in the system was managed by the LogManager class, a core component designed to ensure consistent and accurate tracking of user interactions throughout the experiment. The LogManager utilized the Singleton design pattern to maintain a single active instance across all Unity scenes, allowing seamless logging of tracking data during multiple sessions.
The LogManager recorded real-time events, capturing critical details such as precise timestamps and contextual information at the time of the event. During initialization, a uniquely named log file was created based on the date and time, ensuring data integrity by avoiding overwrites.

#### Key methods included:
WriteTimeStampedEntry(): Logs each event with its exact timestamp and contextual details.
WriteCSV(): Formats and saves data in a structured CSV file for streamlined post-experiment analysis.
To maintain reliability during real-time operations, the LogManager implemented a dynamic file access strategy. It opened and closed the log file for each entry, preventing file access errors that could occur due to scene transitions or application focus loss. This approach ensured uninterrupted data logging, regardless of the system state.

The study was structured into the following stages:

**Menu and Instruction:** Participants navigated through an initial menu and an instructional scene outlining the task objectives.

**Topic Sessions:**
Participants engaged in two 5-minute sessions, each corresponding to one of two randomized topics.
The order of topics (Topic 1 and Topic 2) was randomized to counterbalance potential biases.
Participants could choose to sit or stand during the sessions based on their comfort.

**Questionnaires:**
After each session, participants completed a recall questionnaire shared via Microsoft Teams to evaluate retention of the session content.
At the end of the study, participants filled out a final questionnaire to assess their overall experience with the system.
Each session was carefully designed to capture user interactions through eye tracking, head tracking, and verbal interruptions, which were logged at 20-millisecond intervals. These metrics provided a comprehensive dataset for analysis, detailing user attentiveness and engagement with the system.

#### Data Analysis

The recorded data was exported as CSV files and subjected to statistical analysis. Metrics such as mean, standard deviation, and frequency distributions were calculated to interpret participant behavior and system performance. Insights from eye tracking, head tracking, and verbal interruption logs were correlated with questionnaire responses to assess the system’s effectiveness in training active listening skills.

This systematic data collection and analysis framework ensured reliable results, enabling detailed evaluation of the participants' engagement and the system’s impact on their active listening abilities.

## **Results:**
```markdown
## Overview
The experiment involved 5 participants who engaged with the Active Listening Agent in two distinct sessions. The sessions were presented in random order to minimize potential order bias.

Session 1: A minimally animated topic discussing the impact of artificial intelligence on the job market.
Session 2: A dynamic and expressive description of a visit to Universal Studios.

Results are categorized into the following subsections: User Interaction Dynamics and Measurement of Active Listening in AR.

## User Interaction Dynamics
### Eye Tracking and Session Analysis
Participants' gaze behavior was tracked to measure attention toward the character's head and upper body. Below are the aggregated findings:
Key Observations:

Focus on the head increased in Session 2, suggesting participants paid closer attention to facial expressions and gestures.
The body consistently captured a significant portion of focus due to participants' seating positions.
Eye tracking by topic revealed differences in engagement:

AI Jobs: Focus on Head = 30.38%, Focus on Body = 39.56%
Universal Studios: Focus on Head = 32.9%, Focus on Body = 33.9%

### Head Tracking
Participants’ head orientation (pitch angles) was analyzed to measure attentiveness. Normalized data highlighted trends:

Stable head positions indicated attentiveness during dialogue.
Increased movement corresponded to animated gestures by the agent, suggesting heightened engagement.

### Verbal Interruptions
Interruptions were logged by monitoring spikes in microphone input volume. Key findings:

Interruptions were influenced by session content and participant behavior.
Example: Participant 3 interrupted 5 times during "AI Jobs," while Participant 4 recorded none.

## Measuring Active Listening in AR
To assess active listening, eye-tracking data was correlated with recall questionnaire scores:
Key Insights:
Higher focus percentages were generally associated with higher recall scores.
Other factors, such as topic familiarity and interest, also influenced performance.


[Download Full Dissertation](link-to-pdf)
```
## Future Enhancements
- Adding more diverse virtual agents.
- Implementing AI-driven adaptive feedback mechanisms.
- Expanding the system to support multi-user scenarios.

## Acknowledgments
- **Dr. Ulysses Bernardet**: Project supervisor.
- My fellow participants and testers for their valuable feedback.

If you have any questions or feedback, feel free to reach out at [ososeinegbedion@gmail.com].
