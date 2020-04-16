namespace DraftR.Shared

type ScoringCategories = 
    {
        dstBlockedExtraPoint: float
        dstBlockedFieldGoal: float
        dstBlockedFieldGoalReturnTouchdown: float
        dstBlockedPunt: float
        dstBlockedPuntReturnTouchdown: float
        dstExtraPointReturnTouchdown: float
        dstExtraPointSafety: float
        dstFumbleRecovered: float
        dstFumbleReturnTouchdown: float
        dstInterception: float
        dstInterceptionReturnTouchdown: float
        dstKickReturnTouchdown: float
        dstPointsAllowed0: float
        dstPointsAllowed13: float
        dstPointsAllowed17: float
        dstPointsAllowed20: float
        dstPointsAllowed27: float
        dstPointsAllowed34: float
        dstPointsAllowed45: float
        dstPointsAllowed46Plus: float
        dstPointsAllowed6: float
        dstPuntReturnTouchdown: float
        dstSack: float
        dstSafety: float
        dstYardsAllowed100: float
        dstYardsAllowed150: float
        dstYardsAllowed200: float
        dstYardsAllowed250: float
        dstYardsAllowed300: float
        dstYardsAllowed350: float
        dstYardsAllowed400: float
        dstYardsAllowed450: float
        dstYardsAllowed50: float
        dstYardsAllowed500: float
        dstYardsAllowed550: float
        dstYardsAllowed550Plus: float
        extraPointMade: float
        extraPointMissed: float
        fieldGoalMade29: float
        fieldGoalMade39: float
        fieldGoalMade49: float
        fieldGoalMade50Plus: float
        fieldGoalMissed: float
        fumbleLost: float
        fumbleRecovered: float
        fumbleReturnTouchdown: float
        kickReturnTouchdown: float
        puntReturnTouchdown: float
        pass2Pt: float
        passAttempt: float
        passCompletion: float
        passInterception: float
        passTouchdown: float
        passYardBonus300: float
        passYardBonus350: float
        passYardBonus400: float
        passYardsPerPoint: float
        rec2Pt: float
        recAttempt: float
        recTouchdown: float
        recYardBonus100: float
        recYardBonus150: float
        recYardBonus200: float
        recYardsPerPoint: float
        rush2Pt: float
        rushAttempt: float
        rushTouchdown: float
        rushYardBonus100: float
        rushYardBonus150: float
        rushYardBonus200: float
        rushYardsPerPoint: float
    }

type DraftStyle = 
    | Snake
    | Straight

type ScoringStyle = 
    | Points
    | Roto

type Position = 
    | QB
    | RB
    | WR
    | TE
    | K
    | IDP
    | DST
    | R

type RosterSlot = Position list

type Team = 
    {
        teamId: int
        name: string
        draftPosition: int
    }

type Settings = 
    {
        draft: DraftStyle
        scoring: ScoringStyle
        //categories: ScoringCategories
        roster: RosterSlot list
        teams: Team list
    }
with static member CreateDefault = 
       {
           draft = Snake
           scoring = Roto
           //categories = 
           roster = [
               [QB]; [RB]; [RB]; [WR]; [WR]; [WR]; [WR]; [TE]; [RB; WR; TE;]; [K]; [DST];
           ];
           teams = [
               {teamId = 1;  name = "Team 1";  draftPosition = 1;};
               {teamId = 2;  name = "Team 2";  draftPosition = 2;};
               {teamId = 3;  name = "Team 3";  draftPosition = 3;};
               {teamId = 4;  name = "Team 4";  draftPosition = 4;};
               {teamId = 5;  name = "Team 5";  draftPosition = 5;};
               {teamId = 6;  name = "Team 6";  draftPosition = 6;};
               {teamId = 7;  name = "Team 7";  draftPosition = 7;};
               {teamId = 8;  name = "Team 8";  draftPosition = 8;};
               {teamId = 9;  name = "Team 9";  draftPosition = 9;};
               {teamId = 10; name = "Team 10"; draftPosition = 10;};
               {teamId = 11; name = "Team 11"; draftPosition = 11;};
               {teamId = 12; name = "Team 12"; draftPosition = 12;};
           ]
       }

module rec Draft =
     
    let numberOfPlayersPerTeam (rosterSlots: RosterSlot list) = 
        rosterSlots.Length

    let isInRosterSlot position (rosterSlot: RosterSlot) = 
        List.exists (fun p -> match p with pos when p = position -> true | _ -> false) rosterSlot

    let numberOfPosition position rosterSlots =
        rosterSlots 
        |> List.fold (fun n rosterSlot -> match (isInRosterSlot position rosterSlot) with true -> n + 1 | false -> n) 0

    

