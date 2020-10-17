SELECT P.TEAM_ID "TeamId",
       P.PLAYER_ID "PlayerId",
       P.FIRST_NAME "FirstName",
       P.LAST_NAME "LastName",
       P.DATE_OF_BIRTH "DateOfBirth",
       P.POSITION_CD "PositionCode",
       P.TRANSFER_COST "TransferCost"
    FROM SYSTEM.PLAYER P
    WHERE P.TEAM_ID = :TeamId