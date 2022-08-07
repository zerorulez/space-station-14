### Special messages used by internal localizer stuff.

# Used internally by the PRESSURE() function.
zzzz-fmt-pressure = { TOSTRING($divided, "G3") } { $places ->
    [0] kPa
    [1] MPa
    [2] GPa
    [3] TPa
    [4] PBa
    *[5] ???
}

# Used internally by the POWERWATTS() function.
zzzz-fmt-power-watts = { TOSTRING($divided, "G3") } { $places ->
    [0] W
    [1] kW
    [2] MW
    [3] GW
    [4] TW
    *[5] ???
}

# Used internally by the POWERJOULES() function.
# Reminder: 1 joule = 1 watt for 1 second (multiply watts by seconds to get joules).
# Therefore 1 kilowatt-hour is equal to 3,600,000 joules (3.6MJ)
zzzz-fmt-power-joules = { TOSTRING($divided, "G3") } { $places ->
    [0] J
    [1] kJ
    [2] MJ
    [3] GJ
    [4] TJ
    *[5] ???
}

# Used internally by the THE() function.
zzzz-the = { PROPER($ent) ->
    *[false] o(a) { $ent }
     [true] { $ent }
    }

# Used internally by the SUBJECT() function.
zzzz-subject-pronoun = { GENDER($ent) ->
    [male] ele
    [female] ela
    [epicene] eles
   *[neuter] eles
   }

# Used internally by the OBJECT() function.
zzzz-object-pronoun = { GENDER($ent) ->
    [male] dele
    [female] dela
    [epicene] deles
   *[neuter] deles
   }

# Used internally by the POSS-PRONOUN() function.
zzzz-possessive-pronoun = { GENDER($ent) ->
    [male] dele
    [female] dela
    [epicene] deles
   *[neuter] deles
   }

# Used internally by the POSS-ADJ() function.
zzzz-possessive-adjective = { GENDER($ent) ->
    [male] seu
    [female] sua
    [epicene] seus
   *[neuter] seus
   }

# Used internally by the REFLEXIVE() function.
zzzz-reflexive-pronoun = { GENDER($ent) ->
    [male] ele mesmo
    [female] ela mesma
    [epicene] eles mesmos
   *[neuter] eles mesmos
   }

# Used internally by the CONJUGATE-BE() function.
zzzz-conjugate-be = { GENDER($ent) ->
    [epicene] são
   *[other] é
   }

# Used internally by the CONJUGATE-HAVE() function.
zzzz-conjugate-have = { GENDER($ent) ->
    [epicene] têm
   *[other] tem
   }
