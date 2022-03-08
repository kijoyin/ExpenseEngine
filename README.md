# Expense Engine
The goal of expense engine is to store,sort, categorise expenses and suggest improvements to save money.

### Enity Relationship Diagram
```plantuml

    @startuml
    ' hide the spot
    hide circle

    ' avoid problems with angled crows feet
    skinparam linetype ortho
package "Expense Engine"
{
    entity "User" as usr {
    *id : Guid <<generated>>
    --
    *name : text
    *username:string
    description : text
    }

    entity "TenantUser(Mapping)" as tu {
    *id : Guid <<generated>>
    --
    *tenant_id : Guid <<FK>>
    *user_id : Guid <<FK>>
    *permission_id* : <<FK>>
    }

    entity "Tenant" as tnt {
    *id : Guid <<generated>>
    --
    *name : text
    description : text
    }

    entity "Expense" as ex {
    *id : Guid <<generated>>
    --
    *ownerid:Guid <<FK>>
    *title : string
    *spenddate:date
    *categoryid:Guid <<FK>>
    tags:string
    }

    entity "Category" as ct {
    *id : Guid <<generated>>
    --
    *ownerid:Guid <<FK>>
    *title : string
    description:string
    }
    entity "Permission" as pm {
    *id : Guid <<generated>>
    --
    *ownerid:Guid <<FK>>
    *title : string
    description:string
    }

    tnt }o--|| ex
    tnt }o--|| ct
    ex ||--o{ ct
    usr }|--|{tu
    tnt }|--|{tu
    pm }|--||tu
}

@enduml