# 代码阅读记录
## 简介
### Unity Gameplay Ability System
Unity Gameplay Ability System（简称 GAS）是一个为 Unity 引擎设计的开源能力系统框架，灵感来源于 Unreal Engine 的 Gameplay Ability System（GAS）。它的架构和原理并不基于传统意义上的状态机，而是通过模块化、组件化和数据驱动的方式实现复杂的技能系统。

#### 核心架构模块

Unity Gameplay Ability System 主要由以下三个核心模块构成：
1. 属性系统（Attribute System）‌
   属性系统负责管理角色的各项数值，例如生命值、魔法值、攻击力等。每个属性具有基础值和当前值，并支持加法、乘法、覆盖等多种修改方式。通过统一的属性修改机制，开发者可以轻松实现复杂的属性计算逻辑。

2. 游戏标签系统（Gameplay Tags）‌
   标签系统用于描述角色的状态和条件，支持层级化的标签结构（如 Ability.Skill.Magic.Ice）。它替代了传统的布尔值或枚举判断，简化了状态管理与逻辑判断。例如，一个技能的触发可能需要角色拥有特定的标签。

3. 能力系统（Ability System）‌
   能力系统是整个框架的核心，协调属性系统和标签系统，定义技能的具体执行逻辑。每个能力在适当时机创建并应用游戏效果（Gameplay Effect），从而影响角色的属性和状态。

#### 工作原理
- 能力（Ability）：代表一个可以被触发的行为，比如“施放火球术”或“使用治疗药水”。
- 游戏效果（Gameplay Effect）‌：描述能力对角色产生的具体影响，如增加生命值、施加负面状态等。  
- 修改器（Modifier）：控制属性值如何变化，包括加法、乘法、覆盖等。  
- 游戏标签（Gameplay Tag）‌：用于状态判断和能力激活条件，使系统具备高度灵活性。  
#### 与状态机的关系

虽然 Unity Gameplay Ability System 不是基于传统状态机实现的，但它在某些方面与状态机有相似之处，例如在管理角色状态（如中毒、眩晕）时会使用标签系统进行状态切换。然而，其主要设计思想是模块化和解耦，而不是通过状态转换图来控制行为。这种架构允许开发者更灵活地扩展和复用技能逻辑，避免了传统状态机带来的复杂性和维护困难。

#### 性能与扩展性

该框架内置了性能优化机制，如对象池、缓存机制和批处理逻辑，以应对高频率技能触发和复杂状态管理的需求。同时，它支持自定义扩展，开发者可以根据项目需求添加新的属性类型、标签关系或能力逻辑。

综上所述，Unity Gameplay Ability System 是一套高度模块化、可扩展的游戏能力系统框架，其核心原理围绕属性、标签和能力三大模块展开，而非依赖状态机结构。

#### GAS高级功能
Unity Gameplay Ability System（GAS）具备多项高级功能，使其成为构建复杂游戏技能系统的强大工具。以下是其主要的高级功能：  
1. ‌游戏效果系统（Gameplay Effects）‌  
游戏效果系统支持多种效果类型，包括持续伤害/治疗效果、状态Buff/Debuff以及周期性效果。这些效果可以设置间隔触发和持续时间，允许开发者实现复杂的技能机制，例如持续恢复生命值或施加中毒状态。

2. ‌属性与修改器系统（Attributes & Modifiers）‌  
系统提供灵活的属性管理机制，支持多种修改器类型（如加法、乘法、覆盖等），并允许根据其他属性动态计算修改值。这种设计使得角色属性的变化更加复杂和真实。

3. ‌标签系统（Gameplay Tags）‌  
通过标签系统，可以对技能、效果和状态进行分类和管理。标签支持层级结构，便于实现复杂的条件判断和状态切换。

4. ‌能力任务系统（Ability Tasks）‌  
支持异步能力任务，例如等待动画触发或响应外部事件，使技能执行更加灵活和自然。

5. ‌技能动画与输入系统集成‌  
系统支持与Unity动画控制器的集成，允许技能触发时播放相应的动画效果，提升游戏体验。

6. ‌多玩家同步支持‌  
Unity GAS支持与多种网络框架（如Mirror、Netcode、Photon）集成，确保技能在多人游戏中的同步性。

7. ‌可扩展的架构设计‌  
框架采用模块化设计，允许开发者根据项目需求扩展功能，例如自定义能力、效果或修改器。

8. ‌可视化编辑工具‌  
部分实现提供图形化编辑器，允许设计师通过可视化界面创建和调整技能系统，减少代码编写需求。

这些功能共同构成了一个强大而灵活的技能系统框架，适用于RPG、动作游戏等多种类型的游戏开发。


### 主流MOBA游戏实现

王者荣耀等主流MOBA游戏通常采用‌基于组件和状态标签的系统‌来管理技能和Buff，而不是传统意义上的状态机。这种机制更接近于Unity Gameplay Ability System（GAS）或虚幻引擎的Gameplay Ability System（GAS）的设计理念，而非简单的状态转换图。

1. ‌组件化与标签系统‌  
在主流游戏中，技能和Buff的管理通常基于以下组件和机制：
- 属性系统（Attribute System）‌：用于管理角色的基础属性，如生命值、魔法值、攻击力等。这些属性可以被技能或Buff动态修改。  
- 游戏标签系统（Gameplay Tags）‌：用于标记角色的状态或技能效果。例如，一个角色可能拥有Buff.Stun、Debuff.Slow等标签，便于系统快速识别和处理。  
- 游戏效果系统（Gameplay Effects）‌：定义技能或Buff的具体效果，例如增加攻击力、施加持续伤害等。这些效果可以是瞬时的或持续性的。  
2. ‌状态管理机制‌  
虽然不是传统意义上的状态机，但主流游戏会使用类似的状态管理机制来处理技能和Buff的生命周期：
- 状态的添加与移除‌：通过标签系统或状态管理器来添加或移除角色的状态（如中毒、眩晕、加速等）。  
- 效果的叠加与覆盖‌：通过设定规则来处理多个相同或不同效果的叠加，例如“同类效果取最大值”或“线性叠加”。  
- 生命周期管理‌：通过持续时间、触发条件等机制控制Buff或技能的生效时间。  
3. ‌与Unity GAS的相似性‌  
Unity Gameplay Ability System（GAS）的设计思想与主流游戏的技能系统有诸多相似之处：
- 能力（Ability）‌：代表一个可以被触发的行为，例如施放技能。  
- 效果（Gameplay Effect）‌：描述技能或Buff对角色产生的具体影响。  
- 属性（Attribute）‌：管理角色的数值，如生命值、攻击力等。  
- 标签（Gameplay Tag）‌：用于状态判断和技能激活条件。  
4. ‌网络同步与性能优化‌
主流游戏在实现技能和Buff系统时，还会考虑以下因素：
- 网络同步‌：通过状态同步而非帧同步来保证多人游戏的流畅性，服务器作为权威源管理游戏状态。  
- 性能优化‌：通过缓存标签查询结果、优化属性计算等方式减少性能开销。  

**总结**

主流MOBA游戏（如王者荣耀）在技能和Buff管理上，采用的是‌基于组件和标签的系统‌，这种系统更接近Unity Gameplay Ability System（GAS）或虚幻引擎的GAS，而不是传统意义上的状态机。这种设计使得系统具备高度的灵活性和可扩展性，便于实现复杂的技能逻辑和状态管理。
### 虚幻引擎的GAS
虚幻引擎的 Gameplay Ability System (GAS) 是一个功能强大的技能系统框架，主要用于管理游戏中的能力、属性和状态效果。其核心功能包括：

#### 主要功能
1. 属性系统（Attribute System）‌  
- 管理角色的基础属性如生命值、魔法值、攻击力等
- 支持属性值的动态修改和计算
- 提供加法、乘法、覆盖等多种修改方式

2. 能力系统（Ability System）‌  
- 定义和管理各种游戏能力（技能）
- 支持能力的激活、执行和取消
- 提供能力任务（Ability Tasks）机制处理异步操作

3. 游戏效果系统（Gameplay Effect System）‌  
- 定义技能和状态效果的具体行为
- 支持持续性效果和瞬时效果
- 可设置效果的持续时间、触发条件等

4. 标签系统（Gameplay Tags）‌  
- 用于标记和分类游戏对象的状态
- 支持层级化标签结构
- 便于状态判断和条件检查
- 底层实现机制

#### 组件化架构‌
GAS采用组件化设计，将能力、属性、效果等概念分解为独立的组件，通过组合实现复杂的游戏逻辑

#### 数据驱动设计‌
系统大量使用数据表和配置文件来定义能力行为，减少硬编码，提高可扩展性

#### 状态管理机制‌
通过Gameplay Effect和Gameplay Tag系统来管理角色状态，而非传统状态机

#### 网络同步支持‌
内置网络同步机制，确保多玩家环境下技能执行的一致性

#### 性能优化‌
采用对象池、缓存机制等优化技术，提高系统运行效率

这套机制使得开发者能够构建复杂而灵活的技能系统，同时保持良好的性能和可维护性。

## 代码组织结构
- Assets/
  - My Gameplay Ability System/  : UGAS使用示例
    - Ability System/ 
    - Attributes/
    - Gameplay Tags/    : 标签[GameplayTagScriptableObject](Packages/com.sjai013.abilitysystem/Runtime/gameplay-tags/Authoring/GameplayTagScriptableObject.cs)的实例，通过Unity菜单创建的Unity Asset,
  - Scripts/ : 实现了角色、怪物的管理脚本
  - Input/   : InputSystem实现的输入管理
- Packages/
  - com.sjai013.abilitysystem/   : UGAS内核
    - Runtime/    : Unity package标准文件夹
      - ability-system/    : 能力系统
      - attribute-system/  : 属性系统
      - gameplay-tags/     : 标签系统

## 代码实现
下面只列一些主要的类和文件

| 模块                                 | 代码                                                                                                                                                      | 说明                                                                                                                                         |
|:-----------------------------------|:--------------------------------------------------------------------------------------------------------------------------------------------------------|:-------------------------------------------------------------------------------------------------------------------------------------------|
| com.sjai013.abilitysystem/Runtime/ | <hr style="height: 4px; background: linear-gradient(to right, #A00, #FF0);">                                                                            | <hr style="height: 4px; background: linear-gradient(to right, #FF0, #A00);">                                                               |
| ability-system                     | 能力系统                                                                                                                                                    |                                                                                                                                            |
|                                    | [**AbilitySystemCharacter**](Packages/com.sjai013.abilitysystem/Runtime/ability-system/Components/AbilitySystemCharacter.cs)                            | **入口，看懂这个即可** <br/>  ability系统的调度，继承自MonoBehaviour,在Update中实现游戏效果的驱动，更新效果，删掉失效的 (游戏效果是一些属性值)                                               |
|                                    | [AbilityTags](Packages/com.sjai013.abilitysystem/Runtime/ability-system/Authoring/AbilityTags.cs)                                                       | 定义了能力可以被触发的条件，包括<br/>触发条件：取消标签列表，阻塞标签列表，主角色要求标签列表，源角色要求标签列表，目标角色标签列表<br />生效时附加给owner的标签，                                                  |
|                                    | [GameplayEffectDefinitionContainer](Packages/com.sjai013.abilitysystem/Runtime/ability-system/GameplayEffectDefinitionContainer.cs)                     | 游戏特效持续类型:立刻生效然后移除、永久性，持续一段时间<br/> 类型修改器列表                                                                                                  |
|                                    | [GameplayEffectSpec](Packages/com.sjai013.abilitysystem/Runtime/ability-system/GameplayEffectSpec.cs)                                                   | 游戏特效描述符（配置类？？）                                                                                                                             |
|                                    | [GameplayEffectTags](Packages/com.sjai013.abilitysystem/Runtime/ability-system/GameplayEffectTags.cs)                                                   | 游戏特效标签，包括生效时赋予角色的标签，移除条件，开关条件，生效条件                                                                                                         |
|                                    | [GameplayEffectModifier](Packages/com.sjai013.abilitysystem/Runtime/ability-system/GameplayEffectModifier.cs)                                           | 游戏特效修改器，定义了游戏效果的修改方法（加，乘，覆盖），                                                                                                              |
|                                    | [GameplayEffectPeriod](Packages/com.sjai013.abilitysystem/Runtime/ability-system/GameplayEffectPeriod.cs)                                               | 游戏特效持续时间，是否立刻执行                                                                                                                            |
|                                    | [GameplayEffectScriptableObject](Packages/com.sjai013.abilitysystem/Runtime/ability-system/Authoring/GameplayEffectScriptableObject.cs)                 | 游戏特效wrapper类，包括成员 GameplayEffectDefinitionContainer, GameplayEffectTags,GameplayEffectPeriod                                               |
|                                    | [AbstractAbilityScriptableObject](Packages/com.sjai013.abilitysystem/Runtime/ability-system/Authoring/AbstractAbilityScriptableObject.cs)               | 能力抽象类， 技能触发条件，特效，冷却，抽象方法CreateSpec                                                                                                         |
|                                    | [SimpleAbilityScriptableObject](Packages/com.sjai013.abilitysystem/Runtime/ability-system/Authoring/SimpleAbilityScriptableObject.cs)                   | 简单能力子类，增加了游戏效果，成员 GameplayEffect，CreateSpec创建 SimpleAbilitySpec                                                                            |
|                                    | [InitialiseStatsAbilityScriptableObject](Packages/com.sjai013.abilitysystem/Runtime/ability-system/Authoring/InitialiseStatsAbilityScriptableObject.cs) | 初始游戏效果，增加了游戏效果集合，                                                                                                                          |
|                                    | [AbstractAbilitySpec](Packages/com.sjai013.abilitysystem/Runtime/ability-system/Authoring/AbstractAbilitySpec.cs)                                       | 抽象能力描述符，成员包括Ability，owner，Level，isActive                                                                                                   |
|                                    | [SimpleAbilitySpec](Packages/com.sjai013.abilitysystem/Runtime/ability-system/Authoring/SimpleAbilityScriptableObject.cs)                               | 实现简单的技能条件检查和技能释放                                                                                                                           |
|                                    | [InitialiseStatsAbility](Packages/com.sjai013.abilitysystem/Runtime/ability-system/Authoring/InitialiseStatsAbilityScriptableObject.cs)                 | 释放所有游戏效果                                                                                                                                   |
| gameplay-tags                      | 标签系统                                                                                                                                                    |                                                                                                                                            |
|                                    | [GameplayTagScriptableObject](Packages/com.sjai013.abilitysystem/Runtime/gameplay-tags/Authoring/GameplayTagScriptableObject.cs)                        | 标签基类, 只包含一个属性 Parent，用于层级管理标签，示例：[Ability.Skill.Magic](Assets/My Gameplay Ability System/Gameplay Tags/Ability.Skill.Magic.asset)          |
| attribute-system                   | 属性系统                                                                                                                                                    |                                                                                                                                            |
|                                    | [AttributeScriptableObject](Packages/com.sjai013.abilitysystem/Runtime/attribute-system/Authoring/AttributeScriptableObject.cs)                         | 属性基类，包含成员(Name，PreAttributeChange，CalculateCurrentAttributeValue)。示例：[Agility](Assets/My Gameplay Ability System/Attributes/Base/Agility.asset) |
|                                    | [AttributeValue](Packages/com.sjai013.abilitysystem/Runtime/attribute-system/Components/AttributeValue.cs)                                              | 包含用于实现属性值计算的两个结构体AttributeValue、AttributeModifier。<br />计算公式：当前值 = （基础值 + 修改值) * ( 1 + 修改比例)。                                              |
|                                    | [AttributeSystemComponent](Packages/com.sjai013.abilitysystem/Runtime/attribute-system/Components/AttributeSystemComponent.cs)                          | Attribute的具体操作，和ECS机制类似，但是这里没用c# Extension Methods的方式。<br />实现了AttributeValue的增删改查，值的周期性更新、Event触发。                                        |
|                                    |                                                                                                                                                         |                                                                                                                                            | |                                                                                                                                                 |
| Assets/                            | <hr style="height: 4px; background: linear-gradient(to right, #A00, #FF0);">                                                                            | <hr style="height: 4px; background: linear-gradient(to right, #FF0, #A00);">                                                               | |                                                                                                                                                 |
|                                    | [PlayerController](Assets/Scripts/PlayerController.cs)                                                                                                  | 游戏角色的操控脚本，继承自Unity的MonoBehaviour，FixedUpdate中处理用户的输入：获取用户的移动输入，如果小于0.2忽略，characterController移动对应的向量，同时设置角色的旋转；处理用户的技能操作(鼠标左右键的点击)          | |                                                                                                                                                 |
|  |[AbilityController](Assets/My%20Gameplay%20Ability%20System/Ability%20System/Abilities/AbilityController.cs)||                                                                                                                                                |
||||
||||