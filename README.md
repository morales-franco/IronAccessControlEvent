# IronAccessControlEvent
### Project - Test for Event Feature c#

### Iron Access Control. 
We have 30 users, the access control has the following business rule: It only accepts users whole ages are upper or equal to 18 years.

#### If Register success:
Change Status user to RegisterSuccess

Raise Event to notify  subscribers about this event.

#### If Register NOT success:
Change Status user to RegisterError

Raise Event to notify  subscribers about this event.
